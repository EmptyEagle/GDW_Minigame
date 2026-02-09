using UnityEngine;

public class HitTarget : MonoBehaviour
{
	private StatManager manager;

    void Start()
    {
        manager = GameObject.Find("StatManager").GetComponent<StatManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            manager.AddScore();
        }
    }
}
