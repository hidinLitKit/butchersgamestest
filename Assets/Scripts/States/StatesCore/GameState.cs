using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
	[Header("Enable/Disable Objects")]
	public List<GameObject> views;
	protected const string playerInputMap = "Player", uiInputMap = "UI", deathInputMap = "DeathMap";
	private const string databaseID = "UI";
	[SerializeField] private string _enableClip;
	[SerializeField] private string _disableClip;
	public void Enter()
	{
		gameObject.SetActive(true);
	}

	public void Exit()
	{
		gameObject.SetActive(false);
	}

	protected virtual void OnEnable()
	{
		foreach (var item in views)
		{
			SwitchUiState(true, item);
		}
		//States.instance.enableSource.clip = playEnable ? enableClip: null;
	}

	protected virtual void OnDisable()
	{
		foreach (var item in views)
		{
			SwitchUiState(false, item);
		}
		//States.instance.disableSource.clip = playDisable ? disableClip : null;
	}
	protected void SwitchUiState(bool active, GameObject item)
	{
		CanvasGroup canva;
		if (item && item.TryGetComponent<CanvasGroup>(out canva))
		{
			canva.alpha = active ? 1 : 0;
			canva.interactable = active;
			canva.blocksRaycasts = active;
			return;
		}
		item.SetActive(active);
	}
	public void EnableAudio()
	{
		//SFXManager.instance.PlaySound("UI", _enableClip);
	}
	public void DisableAudio()
	{
		//SFXManager.instance.PlaySound("UI", _disableClip);
	}

}
