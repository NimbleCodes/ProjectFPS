using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    
    void Update()
    {
        transform.position = camPos.position;
    }
}
