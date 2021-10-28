using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
		EnablePlayerInput();
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

	public void DisablePlayerInput()
	{
		_view.heroAttack1Button.interactable = false;
		_view.heroAttack2Button.interactable = false;
		_view.heroAttack3Button.interactable = false;
		_view.heroAttack4Button.interactable = false;
	}

	private void _MonsterTurn()
	{
		DisablePlayerInput();

		_view.monsterIconImage.transform.DOMoveX( _view.monsterIconImage.transform.position.x - 20.0f, 0.2f ).SetLoops( 2, LoopType.Yoyo ).SetEase(Ease.OutExpo);

		this.Invoke( () =>
		{
			Instantiate( _view.fightHitEffect, _view.heroIconImage.transform );
			int damage = Random.Range( 15, 26 );
			Debug.Log( "Monster Attacked : Damage = " + damage );
			_model.heroHp -= damage;
			CheckHeroHp();
		} , 0.4f );
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
			Invoke( nameof( EnablePlayerInput ), TurnTime );
		}
		_UpdateUI();
	}

	private void EnablePlayerInput()
	{
		_view.heroAttack1Button.interactable = true;
		_view.heroAttack2Button.interactable = true;
		_view.heroAttack3Button.interactable = true;
		_view.heroAttack4Button.interactable = true;
	}

	public void HeroAttackMove()
	{
		_view.heroIconImage.transform.DOMoveX( _view.heroIconImage.transform.position.x + 20.0f, 0.2f ).SetLoops( 2, LoopType.Yoyo ).SetEase( Ease.OutExpo );
	}

	public void OnClick_Attack1()
	{
		DisablePlayerInput();
		HeroAttackMove();
		this.Invoke( () =>
		{
			Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
			int damage = Random.Range( heroDamageMin, heroDamageMax );
			Debug.Log( "Attack 1 Clicked : Damage = " + damage );
			monsterHp -= damage;
			CheckMonsterHp();
		}, 0.4f );
	}

	public void OnClick_Attack2()
	{
		DisablePlayerInput();
		HeroAttackMove();
		this.Invoke( () =>
		{
			Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
			int damage = Random.Range( heroDamageMin, heroDamageMax );
			Debug.Log( "Attack 2 Clicked : Damage = " + damage );
			monsterHp -= damage;
			CheckMonsterHp();
		}, 0.4f );
	}

	public void OnClick_Attack3()
	{
		DisablePlayerInput();
		HeroAttackMove();
		this.Invoke( () =>
		{
			Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
			int damage = Random.Range( heroDamageMin, heroDamageMax );
			Debug.Log( "Attack 3 Clicked : Damage = " + damage );
			monsterHp -= damage;
			CheckMonsterHp();
		}, 0.4f );
	}

	public void OnClick_Attack4()
	{
		DisablePlayerInput();
		HeroAttackMove();
		this.Invoke( () =>
		{
			Instantiate( _view.fightHitEffect, _view.monsterIconImage.transform );
			int damage = Random.Range( heroDamageMin, heroDamageMax );
			Debug.Log( "Attack 4 Clicked : Damage = " + damage );
			monsterHp -= damage;
			CheckMonsterHp();
		}, 0.4f );
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