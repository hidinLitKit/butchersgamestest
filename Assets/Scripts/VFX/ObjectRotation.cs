using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private int m_Xrotation;
    [SerializeField, Range(0, 1)] private int m_Yrotation;
    [SerializeField, Range(0, 1)] private int m_Zrotation;
    private float _xDir, _yDir, _zDir;
    private float _rotationPower = 0.25f;
    private void Start()
    {
        RandomDirection(out _xDir);
        RandomDirection(out _yDir);
        RandomDirection(out _zDir);
    }
    void Update()
    {
        transform.rotation *= Quaternion.Euler(_xDir * _rotationPower *m_Xrotation, _yDir * _rotationPower *m_Yrotation, _zDir * _rotationPower*m_Zrotation);
    }
    private void RandomDirection(out float x)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(2) == 0 ? -1 : 1;
        x = randomNumber;
    }
}
