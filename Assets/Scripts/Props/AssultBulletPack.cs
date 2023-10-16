using UnityEngine;

public class AssultBulletPack : MonoBehaviour
{
    int Ammo = 60;

    void OnTriggerEnter(Collider other)
    {
        GameObject AmmoChecker = GameObject.Find("AmmoChecker");
        AmmoChecker.GetComponent<AmmoChecker>().AddAssultRAmmo(Ammo);
        Destroy(gameObject);
    }
}


