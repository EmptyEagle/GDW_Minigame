using UnityEngine;
using System.Collections;

public class ApplyPowerups : MonoBehaviour
{
    private bool[] activePowerups = new bool[3];
    public GameObject[] powerupVisuals;
    private int powerupsLoaded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activePowerups = new bool[3];
        foreach (GameObject visual in powerupVisuals)
        {
            visual.SetActive(false);
        }
        powerupsLoaded = 0;
    }

    public void GrantPowerup(int powerupIndex)
    {
        if (!CheckPowerup(powerupIndex))
        {
            powerupsLoaded++;
        }
        StartCoroutine("PowerupStart", powerupIndex);
        //  Runs into an issue if multiple of the same powerup are hit in succession
    }

    public bool CheckPowerup(int powerupIndex)
    {
        return activePowerups[powerupIndex];
    }

    IEnumerator PowerupStart(int powerupIndex)
    {
        activePowerups[powerupIndex] = true;
        powerupVisuals[powerupIndex].SetActive(true);
        Debug.Log("Granted powerup: "+powerupIndex);
        if (powerupIndex == 1 || powerupIndex == 2)
        {
            yield return new WaitForSeconds(15);
        }
        else
        {
            yield return new WaitForSeconds(10);
        }
        activePowerups[powerupIndex] = false;
        powerupVisuals[powerupIndex].SetActive(false);
        powerupsLoaded--;
        Debug.Log("Removed powerup: "+powerupIndex);
    }
}
