using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    Rigidbody _rig;
    float _speed;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }
    public void Init(float speed)
    {
        _speed = speed;
        Destroy(gameObject, 2f);                    //���� 2�ʵ� �Ѿ� �ı�
    }

    private void Update()
    {
        _rig.AddForce(Vector3.forward * _speed);
    }
}
