using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(PlayerModel))]
public class Player : MonoBehaviour
{
    [SerializeField] float m_maxScore;
    private PlayerModel _model;
    private float _score;
    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
        _score = 25f;
    }

    private void Start()
    {
        _model.SetPlayer(PlayerType.Poor);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            //GameEvents.instance.playerSize.Value += 1;
            _score += other.GetComponent<Collectable>().Value;

            other.GetComponent<Collider>().enabled = false;
            other.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                Destroy(other.gameObject);
            });

            CheckScore();
        }
        if (other.tag == "Obstacle")
        {
            /*playerAnim.SetTrigger("kick");
            other.GetComponent<Block>().CheckHit(); */
        }
        if (other.tag == "Gate")
            //other.GetComponent<Gate>().ExecuteOperation();
        if (other.tag == "Saw")
        {
            /*GameEvents.instance.gameLost.SetValueAndForceNotify(true);
            bloodParticles.SetActive(true);
            GetComponent<Collider>().enabled = false;*/
        }
        if (other.tag == "Finish")
        {
            /* GameEvents.instance.gameWon.SetValueAndForceNotify(true);*/
            States.instance.Push<WinState>();
        }
    }
    private void CheckScore()
    {
        if (_score <= 0)
        {
            States.instance.Push<LoseState>();
            return;
        }
        GameEvents.ChangeScore(_score, m_maxScore);
        ModelFlip();
    }
    private void ModelFlip()
    {
        if (_score <= m_maxScore * 0.33f) _model.SetPlayer(PlayerType.Poor);
        else if (_score <= m_maxScore * 0.77f) _model.SetPlayer(PlayerType.Decent);
        else _model.SetPlayer(PlayerType.Rich);
    }
}
