using UnityEngine;

public class OncomingVehicle : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Aracı kendi baktığı yöne (ileriye) doğru sabit hızla hareket ettirir
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}