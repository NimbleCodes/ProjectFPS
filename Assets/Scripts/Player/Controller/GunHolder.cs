using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    private void Start() {
        for(int i =1; i < weapons.Length;i++){
            weapons[i].SetActive(false);
        }
    }
}
