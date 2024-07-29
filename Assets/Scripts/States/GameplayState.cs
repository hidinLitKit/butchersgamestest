using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameState
{
	protected override void OnEnable()
	{
		base.OnEnable();
		GameEvents.GameStart();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
}
