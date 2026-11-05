using UnityEngine;

public class PlayerController : MonoBehaviour


{
    public float speed = 10;
    
    void Start()
    {
       
    }

    
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
