using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody _rig;
    float x, z; //Movement Velocity value
    
    void Start()
    {
        
        _rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal") * _speed;
        z = Input.GetAxisRaw("Vertical") * _speed;
        _rig.velocity = new Vector3(x, _rig.velocity.y, z);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rig.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    IEnumerator Dash()
    {
        _rig.useGravity = false;
        _rig.AddForce(Vector3.forward * 400, ForceMode.Force);

        yield return new WaitForSeconds(0.5f);

        _rig.useGravity = true;

    }
}
