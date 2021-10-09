using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameplayController : MonoBehaviour
{
	private GameplayView _view;
	private GameplayModel _model;

	private void Start()
	{
		_view = GameplayRoot.Instance.view;
		_model = GameplayRoot.Instance.model;
	}

	public void GameStart()
	{
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
		_view.heroView.waypointsTraveler.countToMove = diceResult;
		_view.heroView.waypointsTraveler.Move(true);
		yield return new WaitWhile( ()=>_view.heroView.waypointsTraveler.IsMoving );
		_view.rollDiceButton.GetComponent<Button>().interactable = true;
	}
}