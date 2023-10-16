using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    void Start()
    {
        camPos = GameObject.FindGameObjectWithTag("CamPos").transform;
    }
    void Update()
    {
        transform.position = camPos.position;
    }
}
