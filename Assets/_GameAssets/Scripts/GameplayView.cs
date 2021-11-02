using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour
{
	public Button rollDiceButton;
	public HeroMovement heroView;
	public GameBoard board;
	public Text rollCount;
	public Text diceResult1;
	public Text diceResult2;
	public DiceImage diceResultImage1;
	public DiceImage diceResultImage2;
	public Text heroHpText;
	public Text monsterHpText;
	public Text fightTitle;
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
	public Sprite tileIconMoveBack;
	public Sprite tileIconWin;
	public Sprite tileIconLose;
	public Sprite tileIconMonsterFight;
	public Sprite tileIconMinigame1;
	public Sprite tileIconMinigame2;
	public Sprite tileIconMinigame3;
}