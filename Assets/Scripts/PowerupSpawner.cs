using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    private float spawnXRange = 50;
    private float xStart;
    public GameObject[] powerupPrefabs;
    private GameObject chosenPowerup;
    private float startDelay = 11;
    private float spawnRate = 12;

    void Start()
    {
        InvokeRepeating("SpawnPowerup", startDelay, spawnRate);
    }

    void SpawnPowerup()
    {
        Debug.Log("Spawning powerup");
        chosenPowerup = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        if (Random.Range(0, 2) == 0)
        {
            xStart = spawnXRange;
        }
        else
        {
            xStart = -spawnXRange;
        }
        float spawnY = Random.Range(-5f, 10f);
        float spawnZ = Random.Range(20f, 35f);
        Instantiate(chosenPowerup, new Vector3(xStart, spawnY, spawnZ), chosenPowerup.transform.rotation);
    }
}
