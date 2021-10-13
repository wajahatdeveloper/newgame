using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hero : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	[HideInInspector] public bool isMoving;

	public int currentTileCount = 0;
	public int targetTileCount = 0;

	private GameplayView _view;
	private GameplayModel _model;

	private void Start()
	{
		_view = GameplayRoot.Instance.view;
		_model = GameplayRoot.Instance.model;
	}

	private void OnEnable()
	{
		currentTileCount = 0;
		targetTileCount = 0;
	}

	public void Move( int count )
	{
		isMoving = true;
		_MoveForward( count );
	}

	private void _MoveForward( int count )
	{
		targetTileCount = currentTileCount + count;
		if (targetTileCount >= 63) { targetTileCount = 63; }
		var targetTile = _view.board.tiles[currentTileCount];
		_MoveToTile( targetTile );
	}

	private void _MoveToTile( Tile targetTile )
	{
		transform.DOMove( targetTile.transform.position, 0.5f ).OnComplete(()=> {
			if (currentTileCount < targetTileCount)
			{
				currentTileCount++;
				var targetTile = _view.board.tiles[currentTileCount];
				_MoveToTile( targetTile );
			}
			else
			{
				isMoving = false;
			}
		} );
	}
}