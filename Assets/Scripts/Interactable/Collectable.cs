using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private ParticleSystem _destroyParticle;
    public float Value => _value;
    private void Awake()
    {
        gameObject.tag = "Collectable";
    }
    private void OnDestroy()
    {
        Instantiate(_destroyParticle, transform);
    }
}
