using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameplayModel;

public class BoardTile : MonoBehaviour
{
	public void CopyFrom(BoardTile tile)
	{
		tileType = tile.tileType;
	}

	public TileType tileType;
}