using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : GameState
{
    protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
	public void ContinueLevel()
    {
		ButchersGames.LevelManager.Default.NextLevel();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
