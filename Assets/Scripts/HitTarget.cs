using UnityEngine;

public class HitTarget : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
