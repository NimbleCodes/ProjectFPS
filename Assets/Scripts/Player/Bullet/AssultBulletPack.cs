using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultBulletPack : MonoBehaviour
{
    int Ammo = 30;

    void OnTriggerEnter(Collider other)
    {
        GameObject AmmoChecker = GameObject.Find("AmmoChecker");
        AmmoChecker.GetComponent<AmmoChecker>().AddAssultRAmmo(Ammo);
    }
}


