using UnityEngine;

public class PlasmaBulletPack : MonoBehaviour
{
    int Ammo = 10;

    void OnTriggerEnter(Collider other)
    {
        GameObject AmmoChecker = GameObject.Find("AmmoChecker");
        AmmoChecker.GetComponent<AmmoChecker>().AddPlasmaCAmmo(Ammo);
        Destroy(gameObject);
    }
}
