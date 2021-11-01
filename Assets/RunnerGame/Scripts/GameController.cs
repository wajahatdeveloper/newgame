using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject sky;
	public GameObject ground;
	public GameObject player;
	public GameObject startPanel;
	public GameObject winPanel;
	public ObstacleSpawner obstacleSpawner;
	public Text timerText;

	public int timer;

	public UnityEvent onWin;
	public UnityEvent onLost;

	private void OnEnable()
	{
		winPanel.SetActive( false );
		startPanel.SetActive( true );
	}

	public void StartGame()
	{
		timer = 10;
		timerText.text = "Time Left : " + timer;
		player.GetComponent<Player>().enabled = true;

		this.Invoke( () => 
		{
			sky.GetComponent<ScrollingTexture>().enabled = true;
			ground.GetComponent<ScrollingTexture>().enabled = true;
			obstacleSpawner.StartSpawning();
			StartCoroutine( Timer() );
		}
		, 1.0f );
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private IEnumerator Timer()
	{
		while (true)
		{
			if (timer <= 0)
			{
				WinPre();
				yield break;
			}
			yield return new WaitForSecondsRealtime( 1.0f );
			timer--;
			timerText.text = "Time Left : " + timer;
		}
	}

	public void WinPre()
	{
		winPanel.SetActive( true );
		sky.GetComponent<ScrollingTexture>().enabled = false;
		ground.GetComponent<ScrollingTexture>().enabled = false;
		obstacleSpawner.StopAllCoroutines();
		GameObject.FindGameObjectsWithTag( "Obstacle" ).ToList().ForEach( ( x ) => Destroy( x, 0.15f ) );
		this.Invoke( () => Win(), 2.0f );
	}

	public void Win()
	{
		Debug.Log( "Lost Runner Won" );
		onWin.Invoke();
	}

	public void LostPre()
	{
		sky.GetComponent<ScrollingTexture>().enabled = false;
		ground.GetComponent<ScrollingTexture>().enabled = false;
		obstacleSpawner.StopAllCoroutines();
		this.Invoke(()=>Lost(), 2.0f);
	}

	public void Lost()
	{
		Debug.Log( "Lost Runner Game" );
		onLost.Invoke();
	}
}