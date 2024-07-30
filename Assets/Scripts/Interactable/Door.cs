using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{
    [SerializeField] private Transform _leftDoor;
    [SerializeField] private Transform _rightDoor;
    private void Awake()
    {
        gameObject.tag = "Door";
    }
    public void OpenDoor()
    {
        RotateDoor(_leftDoor, new Vector3(0, -90, 0));
        RotateDoor(_rightDoor, new Vector3(0, 90, 0));
    }
    private void RotateDoor(Transform door, Vector3 degrees)
    {
        door.DORotate(degrees, 0.5f);
    }
}
