using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour
{
	public Button rollDiceButton;
	public Hero heroView;
	public Board board;
	public Text diceResult;
	public GameObject losePanel;
	public GameObject winPanel;
	public GameObject monsterFightPanel;
	public GameObject minigame1Panel;
	public GameObject minigame2Panel;
	public GameObject minigame3Panel;
	public Sprite tileIconWin;
	public Sprite tileIconLose;
	public Sprite tileIconMonsterFight;
	public Sprite tileIconMinigame1;
	public Sprite tileIconMinigame2;
	public Sprite tileIconMinigame3;
}