using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transform.position.x > 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
