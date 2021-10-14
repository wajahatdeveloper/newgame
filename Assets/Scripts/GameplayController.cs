using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameplayController : MonoBehaviour
{
	public GameplayView _view;
	public GameplayModel _model;
	public MonsterFight monsterFight;

	private List<Tile> randomTiles = new List<Tile>();
	private bool isWorking = false;

	public void GameStart()
	{
		_model.heroHp = 100;
		InitializeRandomBoardData();
		SeedBoardWithRandomData();
	}

	private void InitializeRandomBoardData()
	{
		List<Tile> tmpTiles = new List<Tile>();
		for (int i = 0; i < 38; i++)
		{
			tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.MonsterFight } );
		}
		for (int i = 0; i < 8; i++)
		{
			tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame1 } );
		}
		for (int i = 0; i < 8; i++)
		{
			tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame2 } );
		}
		for (int i = 0; i < 8; i++)
		{
			tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame3 } );
		}
		tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.PlayerLose } );
		tmpTiles.Add( new Tile() { tileType = GameplayModel.TileType.PlayerWin } );
		randomTiles = tmpTiles.Randomize().ToList();
		Debug.Log( "total tile count = " + randomTiles.Count );
	}


	private void SeedBoardWithRandomData()
	{
		int i = 0;
		while (randomTiles.Count > 0)
		{
			var randomTile = randomTiles[0];
			_view.board.tiles[i].CopyFrom( randomTile );
			Sprite spr = null;
			switch (randomTile.tileType)
			{
				case GameplayModel.TileType.MonsterFight:
					spr = _view.tileIconMonsterFight;
					break;
				case GameplayModel.TileType.PlayerWin:
					spr = _view.tileIconWin;
					break;
				case GameplayModel.TileType.PlayerLose:
					spr = _view.tileIconLose;
					break;
				case GameplayModel.TileType.Minigame1:
					spr = _view.tileIconMinigame1;
					break;
				case GameplayModel.TileType.Minigame2:
					spr = _view.tileIconMinigame2;
					break;
				case GameplayModel.TileType.Minigame3:
					spr = _view.tileIconMinigame3;
					break;
				default:
					Debug.LogError( "Icon not found" );
					break;
			}
			_view.board.tiles[i].transform.GetChild( 0 ).GetComponent<SpriteRenderer>().sprite = spr;
			randomTiles.Remove( randomTile );
			i++;
		}
	}

	public void OnClick_RollDice()
	{
		StartCoroutine( RollDice_CR() );
	}

	public IEnumerator RollDice_CR()
	{
		int diceResult = Random.Range( 1, 7 );
		Debug.Log( "Dice result = " + diceResult );
		_view.rollDiceButton.interactable = false;
		_view.diceResult.text = diceResult.ToString();
		_view.heroView.Move( diceResult );
		yield return new WaitWhile( ()=> _view.heroView.isMoving );
		isWorking = true;
		ReadTileData();
		yield return new WaitWhile( () => isWorking );
		_view.rollDiceButton.GetComponent<Button>().interactable = true;
	}

	private void ReadTileData()
	{
		Tile tileData = _view.board.tiles[_view.heroView.currentTileCount];
		Debug.Log( tileData.tileType );
		switch (tileData.tileType)
		{
			case GameplayModel.TileType.MonsterFight:
				monsterFight.StartFight();
				break;
			case GameplayModel.TileType.PlayerWin:
				_view.winPanel.SetActive( true );
				break;
			case GameplayModel.TileType.PlayerLose:
				_view.losePanel.SetActive( true );
				break;
			case GameplayModel.TileType.Minigame1:
				_view.minigame1Panel.SetActive( true );
				break;
			case GameplayModel.TileType.Minigame2:
				_view.minigame2Panel.SetActive( true );
				break;
			case GameplayModel.TileType.Minigame3:
				_view.minigame3Panel.SetActive( true );
				break;
			default:
				break;
		}
		isWorking = false;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}
}

public static class exts
{
	public static IEnumerable<T> Randomize<T>( this IEnumerable<T> source )
	{
		System.Random rnd = new System.Random();
		return source.OrderBy( ( item ) => rnd.Next() );
	}
}