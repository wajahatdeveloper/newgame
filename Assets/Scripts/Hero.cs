using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hero : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	[HideInInspector] public bool isMoving;

	private int currentTileCount = 1;
	private int targetTileCount = 1;

	private GameplayView _view;
	private GameplayModel _model;

	private void Start()
	{
		_view = GameplayRoot.Instance.view;
		_model = GameplayRoot.Instance.model;
	}

	public void Move( int count )
	{
		isMoving = true;
		_MoveForward( count );
	}

	private void _MoveForward( int count )
	{
		targetTileCount = currentTileCount + count;
		if (targetTileCount > 64) { targetTileCount = 64; }
		var targetTile = _view.board.tiles[currentTileCount - 1];
		_MoveToTile( targetTile );
	}

	private void _MoveToTile( Tile targetTile )
	{
		transform.DOMove( targetTile.transform.position, 0.5f ).OnComplete(()=> {
			if (currentTileCount < targetTileCount)
			{
				currentTileCount++;
				var targetTile = _view.board.tiles[currentTileCount - 1];
				_MoveToTile( targetTile );
			}
			else
			{
				isMoving = false;
			}
		} );
	}
}