using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : GameState
{
	protected override void OnEnable()
	{
		base.OnEnable();
		GameEvents.Lose();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
	public void RestartLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		/*ButchersGames.LevelManager.Default.RestartLevel();
		ButchersGames.LevelManager.Default.StartLevel();

		States.instance.Push<StartState>();*/
    }
}
