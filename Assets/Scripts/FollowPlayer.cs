using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera; // Arkadan takip eden kamera
    public Camera hoodCamera; // Sürücü / Kaput kamerası
    public Key switchKey = Key.C; // Kamera değiştirme tuşu (Varsayılan: C)

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;

        // Başlangıçta ana kamera açık, sürücü kamerası kapalı olsun
        if (mainCamera != null && hoodCamera != null)
        {
            mainCamera.enabled = true;
            hoodCamera.enabled = false;
        }
    }

    void Update()
    {
        // Tuşa basıldığında kameraları birbirinin tersi durumuna getir (Aç/Kapat)
        if (Keyboard.current != null && Keyboard.current[switchKey].wasPressedThisFrame)
        {
            if (mainCamera != null && hoodCamera != null)
            {
                mainCamera.enabled = !mainCamera.enabled;
                hoodCamera.enabled = !hoodCamera.enabled;
            }
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}