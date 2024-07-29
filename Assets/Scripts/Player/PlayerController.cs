using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_limitX;
    [SerializeField] private float m_sidewaySpeed;
    [SerializeField] private Transform m_player;

    private bool _lockControls;
    private float _finalPos;
    private float _currentPos;

    private void OnEnable()
    {
        GameEvents.onGameStart += UnlockControls;
        GameEvents.onLose += LockControls;
        GameEvents.onWin += LockControls;
    }
    private void Start()
    {
        StartCoroutine(MovingPlayer());
    }
    private void OnDisable()
    {
        GameEvents.onGameStart -= UnlockControls;
        GameEvents.onLose -= LockControls;
        GameEvents.onWin -= LockControls;
    }
    private void LockControls()
    {
        _lockControls = true;
        StopAllCoroutines();
    }
    private void UnlockControls()
    {
        _lockControls = false;
        StartCoroutine(MovingPlayer());
    }
    IEnumerator MovingPlayer()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            //MovePlayer();
        }
    }
    private void Update()
    {
        MovePlayer();
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
