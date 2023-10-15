using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float timer;
    private void Start()
    {
        Invoke("Destroy", timer);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
