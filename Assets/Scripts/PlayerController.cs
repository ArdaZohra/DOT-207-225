using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 40f;
    public InputAction moveAction;
    private Vector2 moveInput;

    void Start()
    {
        moveAction.Enable();

        // TAKLA ATMAYI KESİN OLARAK KİLİTLER (Sadece Y ekseninde sağa/sola dönebilir)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        transform.Rotate(Vector3.up, turnSpeed * moveInput.x * Time.deltaTime);

        // Yoldan düşerse sahneyi baştan yükle
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}