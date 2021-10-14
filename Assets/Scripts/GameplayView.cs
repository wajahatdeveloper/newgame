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
	public Text heroHpText;
	public Text monsterHpText;
	public GameObject losePanel;
	public GameObject winPanel;
	public GameObject minigame1Panel;
	public GameObject minigame2Panel;
	public GameObject minigame3Panel;
	public GameObject monsterFightPanel;
	public GameObject fightHitEffect;
	public Image fightIconImage;
	public Image heroIconImage;
	public Image monsterIconImage;
	public Button heroAttack1Button;
	public Button heroAttack2Button;
	public Button heroAttack3Button;
	public Button heroAttack4Button;
	public Sprite tileIconWin;
	public Sprite tileIconLose;
	public Sprite tileIconMonsterFight;
	public Sprite tileIconMinigame1;
	public Sprite tileIconMinigame2;
	public Sprite tileIconMinigame3;
}