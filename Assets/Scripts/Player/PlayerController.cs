using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using ButchersGames;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_limitX;
    [SerializeField] private float m_sidewaySpeed;
    [SerializeField] private Transform m_player;
    [SerializeField] private Collider m_playerCollider;
    [SerializeField] private PathCreation.Examples.PathFollower m_follower;

    private float _finalPos;
    private float _currentPos;

    private void OnEnable()
    {
        GameEvents.onGameStart += UnlockControls;
        GameEvents.onLose += LockControls;
        GameEvents.onWin += LockControls;

        LevelManager.Default.OnLevelStarted += ResetPlayer;
    }
    private void OnDisable()
    {
        GameEvents.onGameStart -= UnlockControls;
        GameEvents.onLose -= LockControls;
        GameEvents.onWin -= LockControls;

        LevelManager.Default.OnLevelStarted -= ResetPlayer;
    }
    private void LockControls()
    {
        m_playerCollider.enabled = false;
        m_follower.SetMove(false);
        StopAllCoroutines();
    }
    private void UnlockControls()
    {
        m_playerCollider.enabled = true;
        m_follower.SetMove(true);
        StartCoroutine(MovingPlayer());
    }
    private void ResetPlayer()
    {
        Level lvl = LevelManager.Default.CurrentGameLevel;
        m_player.localPosition = lvl.PlayerSpawnPoint.position;
        m_follower.SetPath(lvl.Path);
    }
    IEnumerator MovingPlayer()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            float percentageX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width * 0.5f) * 2;
            percentageX = Mathf.Clamp(percentageX, -1.0f, 1.0f);
            _finalPos = percentageX * m_limitX;
        }
        var delta = _finalPos - _currentPos;

        _currentPos += (delta * Time.deltaTime * m_sidewaySpeed);
        _currentPos = Mathf.Clamp(_currentPos, -m_limitX, m_limitX);
        m_player.localPosition = new Vector3(0, _currentPos, 0);
    }
}
