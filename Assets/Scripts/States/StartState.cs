using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButchersGames;

public class StartState : GameState
{
	protected override void OnEnable()
	{
		base.OnEnable();
		//LevelManager.Default.StartLevel();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
}
