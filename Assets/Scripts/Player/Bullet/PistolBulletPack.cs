using UnityEngine;

public class PistolBulletPack : MonoBehaviour
{
    int Ammo = 24;

    void OnTriggerEnter(Collider other)
    {
        GameObject AmmoChecker = GameObject.Find("AmmoChecker");
        AmmoChecker.GetComponent<AmmoChecker>().AddPistolAmmo(Ammo);
    }

}
