using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{    
    Rigidbody _rig;
    float _speed,_x,_y,_z;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }
    public void Init(float rotationX, float rotationY,float rotationZ ,float speed)
    {
        _speed = speed;
        _x = rotationX;
        _y = rotationY;
        _z = rotationZ;
        Destroy(gameObject, 2f);                    
    }


    private void Update()
    {
        _rig.AddForce(new Vector3(_x,_y,_z).normalized * _speed);
    }
    
}
