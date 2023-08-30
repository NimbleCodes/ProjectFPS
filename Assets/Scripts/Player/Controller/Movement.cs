using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerdir;
    [SerializeField] private float _drag;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpForce;
    [SerializeField] private float dashCoolTime;
    Rigidbody _rig;
    Vector3 _direction;
    bool _isOnGround, _isDash = false;
    float _playerHeight =2f;
    float x, z; //Movement Velocity value
    
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        _direction = _playerdir.forward * z + _playerdir.right * x;
        _rig.AddForce(_direction.normalized * _speed * 10f, ForceMode.Force);

    }

    private void Update()
    {
        _isOnGround = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.3f, Ground);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround == true)
        {
            _rig.AddForce(Vector3.up * 6, ForceMode.Impulse);
        }

        if(_isOnGround){
            _rig.drag = _drag;
        }else{
            _rig.drag = 0f;
        }
        LimitSpeed();
    }

    void Dash(){
        if(x > 0 && Input.GetKeyDown(KeyCode.LeftShift)){
            _isDash = true;
            Vector3 forceToApply = transform.right * dashForce + transform.up * dashUpForce;
            _rig.AddForce(forceToApply, ForceMode.Impulse);
            Invoke("ResetDash", dashCoolTime);
        }
        if(x < 0 && Input.GetKeyDown(KeyCode.LeftShift)){
            _isDash = true;
            Vector3 forceToApply = -transform.right * dashForce + transform.up * dashUpForce;
            _rig.AddForce(forceToApply, ForceMode.Impulse);
            Invoke("ResetDash", dashCoolTime);
        }
        if(z > 0 && Input.GetKeyDown(KeyCode.LeftShift)){
            _isDash = true;
            Vector3 forceToApply = transform.forward * dashForce + transform.up * dashUpForce;
            _rig.AddForce(forceToApply, ForceMode.Impulse);
            Invoke("ResetDash", dashCoolTime);
        }
        if(z < 0 && Input.GetKeyDown(KeyCode.LeftShift)){
            _isDash = true;
            Vector3 forceToApply = -transform.forward * dashForce + transform.up * dashUpForce;
            _rig.AddForce(forceToApply, ForceMode.Impulse);
            Invoke("ResetDash", dashCoolTime);
        }
    }

    void ResetDash(){
        _isDash = false;
    }
    void LimitSpeed(){
        Vector3 flatValue = new Vector3(_rig.velocity.x, 0f, _rig.velocity.z);
        if(flatValue.magnitude > _speed){                                               //속도가 speed를 넘어가면
            Vector3 speedLimit = flatValue.normalized * _speed;                         //speedLimit 값을 계산하여
            _rig.velocity = new Vector3(speedLimit.x, _rig.velocity.y, speedLimit.z);   //현재 속도 변경
        }
    }
}
