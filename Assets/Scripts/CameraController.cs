using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private float _speedX;
    private float _speedY;

    [SerializeField] private float speed = 0.05f;

    [SerializeField] Transform target;

    public void Update() {
        transform.RotateAround(target.position, Vector3.up, _speedY * Time.deltaTime * speed);
        transform.RotateAround(target.position, Vector3.right, -_speedX * Time.deltaTime * speed);
        transform.LookAt(target);
    }

    public void ChangeY(float value) {
        _speedY = value;
    }

    public void ChangeX(float value) {
        _speedX = value;
    }
}
