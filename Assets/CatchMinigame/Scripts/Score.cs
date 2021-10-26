using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;
	public int ballAmount;
	public int ballToWin;
	public Text gemsLeft;
	public GameController gameController;

	public UnityEngine.Events.UnityEvent onLose;
	public UnityEngine.Events.UnityEvent onWin;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D (Collider2D collision)
	{

		if (collision.gameObject.tag == "Bomb")
		{
			score -= ballValue * 2;
			UpdateScore();
			gameController.startButton.gameObject.SetActive( true );
			onLose?.Invoke();
		}
		else
		{
			score += ballValue;
			UpdateScore();
			ballAmount++;
			gemsLeft.text = "Gems Left: " + (ballToWin - ballAmount);
			if (ballAmount >= ballToWin)
			{
				ballAmount = 0;
				gameController.startButton.gameObject.SetActive( true );
				onWin?.Invoke();
			}
		}

		
	}

	//void OnCollisionEnter2D (Collision2D collision) {
	//	if (collision.gameObject.tag == "Bomb") {
	//		score -= ballValue * 2;
	//		UpdateScore ();
	//		gameController.startButton.gameObject.SetActive (true);
	//		onLose?.Invoke ();
	//	}
	//}

	void UpdateScore () {
		scoreText.text = "Total Score\n" + score;
	}
}
