using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimationType
{
    PoorWalk,
    DecentWalk,
    RichWalk,

}
[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetAnimation(AnimationType _anim)
    {

    }
}
