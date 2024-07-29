using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float m_value;
    [SerializeField] private ParticleSystem m_destroyParticle;
    [SerializeField] private string m_soundId;

    private const string _soundDbId = "Collectables";
    public float Value => m_value;
    private void Awake()
    {
        gameObject.tag = "Collectable";
    }
    private void OnDestroy()
    {
        Instantiate(m_destroyParticle, transform);
        SFXManager.instance.PlaySound(_soundDbId, m_soundId);
    }
}
