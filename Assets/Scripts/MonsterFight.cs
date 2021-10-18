using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFight : MonoBehaviour
{
	private const float TurnTime = 1.0f;
	private const int heroDamageMax = 36;
	private const int heroDamageMin = 20;
	public GameplayView _view;
	public GameplayModel _model;

	private int monsterHp;

	public void StartFight()
	{
		_view.fightTitle.text = "Fighting";
		_view.monsterHpText.text = "100";
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
		CheckHeroHp();
	}

	public void CheckHeroHp()
	{
		if (_model.heroHp <= 0)
		{
			_view.fightTitle.text = "You Lose";
			_view.losePanel.SetActive( true );
		}
		else
		{
			Invoke( nameof( _HeroTurn ), TurnTime );
		}
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
		int damage = Random.Range( heroDamageMin, heroDamageMax );
		Debug.Log( "Attack 1 Clicked : Damage = " + damage );
		monsterHp -= damage;
		CheckMonsterHp();
	}

	public void OnClick_Attack2()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( heroDamageMin, heroDamageMax );
		Debug.Log( "Attack 2 Clicked : Damage = " + damage );
		monsterHp -= damage;
		CheckMonsterHp();
	}

	public void OnClick_Attack3()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( heroDamageMin, heroDamageMax );
		Debug.Log( "Attack 3 Clicked : Damage = " + damage );
		monsterHp -= damage;
		CheckMonsterHp();
	}

	public void OnClick_Attack4()
	{
		Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
		int damage = Random.Range( heroDamageMin, heroDamageMax );
		Debug.Log( "Attack 4 Clicked : Damage = " + damage );
		monsterHp -= damage;
		CheckMonsterHp();
	}

	public void CheckMonsterHp()
	{
		if (monsterHp <= 0)
		{
			_view.fightTitle.text = "You Win";
			Invoke( nameof( ClosePanel ), 1.0f );
		}
		else
		{
			Invoke( nameof( _MonsterTurn ), TurnTime );
		}
		_UpdateUI();
	}

	public void ClosePanel()
	{
		_view.monsterFightPanel.SetActive( false );
	}
}