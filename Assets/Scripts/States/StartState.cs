using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButchersGames;
public class StartState : GameState
{
	protected override void OnEnable()
	{
		base.OnEnable();
		LevelManager.Default.Init();
		//LevelManager.Default.StartLevel();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
	public void StartGame()
    {
		ButchersGames.LevelManager.Default.StartLevel();
		GameEvents.GameStart();
		States.instance.Push<GameplayState>();
		
	}		
}
