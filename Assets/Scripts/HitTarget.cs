using UnityEngine;

public class HitTarget : MonoBehaviour
{
	private StatManager manager;
    private AudioSource targetHitSound;

    void Start()
    {
        manager = GameObject.Find("StatManager").GetComponent<StatManager>();
        targetHitSound = GameObject.Find("TargetHitSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            targetHitSound.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
            manager.AddScore();
        }
    }
}
