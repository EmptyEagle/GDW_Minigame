using UnityEngine;
using System.Collections;

public class FireCannonball : MonoBehaviour
{
    private bool canFire;
    public GameObject projectilePrefab;
    public AudioSource cannonLaunchSound;
    public AudioSource cannonReloadSound;
    public GameObject cannonIndicator;
    private ApplyPowerups activePowerups;

    void Start()
    {
        canFire = true;
        cannonIndicator.SetActive(true);
        activePowerups = GetComponent<ApplyPowerups>();
    }

    public void AttemptFire()
    {
        if (canFire)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        canFire = false;
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        cannonLaunchSound.Play();
        cannonIndicator.SetActive(false);
        if (activePowerups.CheckPowerup(1) && activePowerups.CheckPowerup(2))
        {
            // Both double cannonball and quick reload powerups
            yield return new WaitForSeconds(0.5f);
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            cannonLaunchSound.Play();
            yield return new WaitForSeconds(0.7f);
        }
        else if (activePowerups.CheckPowerup(1))
        {
            // Double cannonball powerup
            yield return new WaitForSeconds(0.7f);
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            cannonLaunchSound.Play();
            yield return new WaitForSeconds(1.3f);
        }
        else if (activePowerups.CheckPowerup(2))
        {
            // Quick reload powerup
            yield return new WaitForSeconds(1.2f);
        }
        else
        {
            yield return new WaitForSeconds(2);
        }
        canFire = true;
        cannonReloadSound.Play();
        cannonIndicator.SetActive(true);
    }
}
