using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hero : MonoBehaviour
{
	private const string animationStateIdle = "Idle";
	private const string animationStateWalk = "Walking";
	public SpriteRenderer spriteRenderer;
	public Animator spriteAnimator;

	[HideInInspector] public bool isMoving;

	private int currentTileCount = 0;
	public int targetTileCount = 0;

	private GameplayView _view;
	private GameplayModel _model;

	public int CurrentTileCount { get => currentTileCount; set => currentTileCount =  Mathf.Clamp(value,0,63); }

	private void Start()
	{
		_view = GameplayRoot.Instance.view;
		_model = GameplayRoot.Instance.model;
	}

	private void OnEnable()
	{
		CurrentTileCount = 0;
		targetTileCount = 0;
	}

	public void Move( int count )
	{
		isMoving = true;
		spriteAnimator.Play( animationStateWalk );
		if (count < 0)
		{
			_MoveBackwards(Mathf.Abs(count));
		}
		else
		{
			_MoveForward( count );
		}
	}

	private void _MoveForward( int count )
	{
		targetTileCount = CurrentTileCount + count;
		if (targetTileCount >= 63) { targetTileCount = 63; }
		var targetTile = _view.board.tiles[CurrentTileCount];
		_MoveToTile( targetTile );
	}

	private void _MoveBackwards( int count )
	{
		targetTileCount = targetTileCount - count;
		currentTileCount = targetTileCount;
		if (targetTileCount <= 0) { targetTileCount = 0; }
		var targetTile = _view.board.tiles[targetTileCount];
		_MoveToTile( targetTile );
	}

	private void _MoveToTile( BoardTile targetTile )
	{
		transform.DOMove( targetTile.transform.position, 0.5f ).OnComplete(()=> {
			if (CurrentTileCount != targetTileCount)
			{
				CurrentTileCount++;
				var targetTile = _view.board.tiles[CurrentTileCount];
				_MoveToTile( targetTile );
			}
			else
			{
				spriteAnimator.Play( animationStateIdle );
				isMoving = false;
			}
		} );
	}
}