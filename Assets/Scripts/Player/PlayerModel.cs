using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum PlayerType
{
    Poor,
    Decent,
    Rich
}
public class PlayerModel : MonoBehaviour
{
    [SerializeField] private List<PlayerRender> m_Players = new List<PlayerRender>();
    
    private PlayerAnimations _animations;
    private void Awake()
    {
        _animations = GetComponentInChildren<PlayerAnimations>();
        ResetPlayer();
    }

    public void SetPlayer(PlayerType type)
    {
        ResetPlayer();

        int index;
        index = m_Players.FindIndex(curr => curr.PlayerType == type);

        _animations.SetAnimation(m_Players[index].AnimationType);
        m_Players[index].SkinType.enabled = true;
    }
    public void SetSpecialAnim(AnimationType type)
    {
        _animations.SetAnimation(type);
    }

    private void ResetPlayer()
    {
        foreach (PlayerRender player in m_Players) player.SkinType.enabled = false;
    }

}
[Serializable]
public class PlayerRender
{
    [SerializeField] private PlayerType m_playerType;
    [SerializeField] private AnimationType m_animType;
    [SerializeField] private SkinnedMeshRenderer m_skinType;

    public AnimationType AnimationType => m_animType;
    public SkinnedMeshRenderer SkinType => m_skinType;
    public PlayerType PlayerType => m_playerType;
}
