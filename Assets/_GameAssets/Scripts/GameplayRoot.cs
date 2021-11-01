using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayRoot : Singleton<GameplayRoot>
{
	public GameplayView view;
	public GameplayModel model;
	public GameplayController controller;

	private void OnEnable()
	{
		controller.GameStart();
	}
}