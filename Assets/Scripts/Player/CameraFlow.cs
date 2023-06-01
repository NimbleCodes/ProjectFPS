using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    float _senceX, _senceY;
    float _rotationX, _rotationY;
    float _mouseX, _mouseY;
    [SerializeField] Transform _orientation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") + Time.deltaTime * _senceX;
        _mouseY = Input.GetAxisRaw("Mouse Y") + Time.deltaTime * _senceY;

        _rotationY += _mouseX;

        _rotationX -= _mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        // rotation of cam and orientation
        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        _orientation.rotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
