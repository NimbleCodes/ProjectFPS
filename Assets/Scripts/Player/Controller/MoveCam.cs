using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    
    void Update()
    {
        transform.position = camPos.position;
    }
}
