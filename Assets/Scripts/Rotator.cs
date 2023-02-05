using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Transform _center; public Transform Center { get { return _center; } set { _center = value; } }
    [SerializeField] float _speed; public float Speed { get { return _speed; } set { _speed = value; } }

    private void Update()
    {
        transform.RotateAround(Vector3.zero, _center.forward, _speed);
    }
}
