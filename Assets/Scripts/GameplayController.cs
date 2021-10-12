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

	private List<Tile> randomTiles = new List<Tile>();
	private bool isWorking = false;

	public void GameStart()
	{
		InitializeRandomBoardData();
		SeedBoardWithRandomData();
	}

	private void SeedBoardWithRandomData()
	{
		for (int i = 0; i < _view.board.tiles.Count; i++)
		{
			var randomTile = randomTiles.Random();
			_view.board.tiles[i].CopyFrom( randomTile );
			randomTiles.Remove( randomTile );
		}
	}

	private void InitializeRandomBoardData()
	{
		for (int i = 0; i < 40; i++)
		{
			randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.MonsterFight } );
		}
		for (int i = 0; i < 8; i++)
		{
			randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame1 } );
		}
		for (int i = 0; i < 8; i++)
		{
			randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame2 } );
		}
		for (int i = 0; i < 8; i++)
		{
			randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.Minigame3 } );
		}
		randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.PlayerLose } );
		randomTiles.Add( new Tile() { tileType = GameplayModel.TileType.PlayerWin } );
		randomTiles = randomTiles.Randomize().ToList();
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
				_view.monsterFightPanel.SetActive( true );
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
	public static T Random<T>( this IEnumerable<T> enumerable )
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException( nameof( enumerable ) );
		}

		// note: creating a Random instance each call may not be correct for you,
		// consider a thread-safe static instance
		var r = new System.Random();
		var list = enumerable as IList<T> ?? enumerable.ToList();
		return list.Count == 0 ? default( T ) : list[r.Next( 0, list.Count )];
	}

	public static IEnumerable<T> Randomize<T>( this IEnumerable<T> source )
	{
		System.Random rnd = new System.Random();
		return source.OrderBy( ( item ) => rnd.Next() );
	}
}