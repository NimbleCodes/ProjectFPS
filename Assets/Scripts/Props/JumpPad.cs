using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float _jumpPower;
    [SerializeField] float _pushPower;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy")){
            GameObject temp = other.gameObject;
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * _pushPower, ForceMode.Impulse);
            temp.GetComponent<Rigidbody>().AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
