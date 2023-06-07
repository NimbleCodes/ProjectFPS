using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerdir;
    [SerializeField] private float _drag;
    [SerializeField] private LayerMask Ground;
    Rigidbody _rig;
    Vector3 _direction;
    bool _isOnGround;
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
            StartCoroutine(Dash());
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

    IEnumerator Dash()
    {
        _rig.useGravity = false;
        _rig.AddForce(Vector3.forward * 400, ForceMode.Force);

        yield return new WaitForSeconds(0.5f);

        _rig.useGravity = true;

    }

    void LimitSpeed(){
        Vector3 flatValue = new Vector3(_rig.velocity.x, 0f, _rig.velocity.z);
        if(flatValue.magnitude > _speed){                                               //속도가 speed를 넘어가면
            Vector3 speedLimit = flatValue.normalized * _speed;                         //speedLimit 값을 계산하여
            _rig.velocity = new Vector3(speedLimit.x, _rig.velocity.y, speedLimit.z);   //현재 속도 변경
        }
    }
}
