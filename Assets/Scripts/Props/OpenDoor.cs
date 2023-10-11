using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator RightDoor;
    [SerializeField] Animator LeftDoor;

    void OnTriggerEnter(Collider other)
    {
        RightDoor.SetBool("OnTrigger",true);
        LeftDoor.SetBool("OnTrigger",true);
    }

    void OnTriggerExit(Collider other)
    {
        RightDoor.SetBool("OnTrigger",false);
        LeftDoor.SetBool("OnTrigger",false);
    }
}
