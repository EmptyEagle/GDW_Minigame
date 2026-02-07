using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }
}
