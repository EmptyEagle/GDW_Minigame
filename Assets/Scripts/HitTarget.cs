using UnityEngine;

public class HitTarget : MonoBehaviour
{
	private StatManager manager;
    private AudioSource targetHitSound;
    private ApplyPowerups powerupSetter;

    void Start()
    {
        manager = GameObject.Find("StatManager").GetComponent<StatManager>();
        targetHitSound = GameObject.Find("TargetHitSound").GetComponent<AudioSource>();
        powerupSetter = GameObject.Find("Cannon").GetComponent<ApplyPowerups>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (gameObject.tag == "Powerup_Speed")
            {
                // Do this if target is a speed powerup
                powerupSetter.GrantPowerup(0);
            }
            else if (gameObject.tag == "Powerup_DoubleLaunch")
            {
                // Do this if target is a double cannonball powerup
                powerupSetter.GrantPowerup(1);
            }
            else if (gameObject.tag == "Powerup_QuickReload")
            {
                // Do this if target is a quick reload powerup
                powerupSetter.GrantPowerup(2);
            }
            else
            {
                manager.AddScore();
            }
            targetHitSound.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
