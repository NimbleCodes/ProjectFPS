using UnityEngine;

public class BlasterBulletPack : MonoBehaviour
{
    int Ammo = 5;
    

    void OnTriggerEnter(Collider other)
    {
        GameObject AmmoChecker = GameObject.Find("AmmoChecker");
        AmmoChecker.GetComponent<AmmoChecker>().AddBlasterAmmo(Ammo);
        Destroy(gameObject);
    }
}
