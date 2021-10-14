using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFight : MonoBehaviour
{
	public GameplayView _view;
	public GameplayModel _model;

	private int monsterHp;

	public void StartFight()
	{
		_view.monsterFightPanel.SetActive( true );
		_view.heroIconImage.sprite = _view.heroView.GetComponent<SpriteRenderer>().sprite;
		monsterHp = 100;
	}

	private void _UpdateUI()
	{
		_view.monsterHpText.text = "HP:" + monsterHp;
		_view.heroHpText.text = "HP:" + _model.heroHp;
	}

	private void _MonsterTurn()
	{
		_view.heroAttack1Button.interactable = false;
		_view.heroAttack2Button.interactable = false;
		_view.heroAttack3Button.interactable = false;
		_view.heroAttack4Button.interactable = false;

		Instantiate( _view.fightHitEffect, _view.heroIconImage.transform );
		int damage = Random.Range( 15, 26 );
		Debug.Log( "Monster Attacked : Damage = " + damage );
		_model.heroHp -= damage;

		Invoke( nameof( _HeroTurn ), 0.5f );
		_UpdateUI();
	}

	private void _HeroTurn()
	{
		_view.heroAttack1Button.interactable = true;
		_view.heroAttack2Button.interactable = true;
		_view.heroAttack3Button.interactable = true;
		_view.heroAttack4Button.interactable = true;
	}

	public void OnClick_Attack1()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( 15, 26 );
		Debug.Log( "Attack 1 Clicked : Damage = " + damage );
		monsterHp -= damage;
		Invoke( nameof( _MonsterTurn ), 0.5f );
		_UpdateUI();
	}

	public void OnClick_Attack2()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( 15, 26 );
		Debug.Log( "Attack 2 Clicked : Damage = " + damage );
		monsterHp -= damage;
		Invoke( nameof( _MonsterTurn ), 0.5f );
		_UpdateUI();
	}

	public void OnClick_Attack3()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( 15, 26 );
		Debug.Log( "Attack 3 Clicked : Damage = " + damage );
		monsterHp -= damage;
		Invoke( nameof( _MonsterTurn ), 0.5f );
		_UpdateUI();
	}

	public void OnClick_Attack4()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( 15, 26 );
		Debug.Log( "Attack 4 Clicked : Damage = " + damage );
		monsterHp -= damage;
		Invoke( nameof( _MonsterTurn ), 0.5f );
		_UpdateUI();
	}
}