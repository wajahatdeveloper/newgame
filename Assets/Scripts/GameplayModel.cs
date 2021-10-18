using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayModel : MonoBehaviour
{
	public enum TileType
	{
		MonsterFight,
		PlayerWin,
		PlayerLose,
		Minigame1,
		Minigame2,
		Minigame3,
	}

	public int heroHp = 100;
	public int rollLimit = 10;
	public int rollCount = 0;
}