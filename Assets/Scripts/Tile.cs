using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameplayModel;

public class Tile : MonoBehaviour
{
	public void CopyFrom(Tile tile)
	{
		tileType = tile.tileType;
	}

	public TileType tileType;
}