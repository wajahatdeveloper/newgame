using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayModel : MonoBehaviour
{
	public class GetPlayerNFTs
	{
		public List<string> heroes { get; set; }
	}

	public static string currentNftCharId;
	public static NFTData currentNftChar;

	public enum TileType
	{
		MonsterFight,
		MoveBack,
		PlayerWin,
		PlayerLose,
		Minigame1,
		Minigame2,
		Minigame3,
	}

	public int heroLevel = 1;
	public int heroTier = 1;
	public int heroHp = 100;
	public int rollLimit = 10;
	public int rollCount = 0;
	public int moveBackCount = 1;
}