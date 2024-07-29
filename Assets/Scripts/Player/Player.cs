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
        _model.SetPlayer(PlayerType.Decent);
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
            GameEvents.Win();
        }
    }
    private void CheckScore()
    {
        if (_score <= 0)
        {
            GameEvents.Lose();
            return;
        }
        GameEvents.ChangeScore(_score % m_maxScore);
    }
}
