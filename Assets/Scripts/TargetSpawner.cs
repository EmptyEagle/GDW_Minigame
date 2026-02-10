using System.Runtime.CompilerServices;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    private float startDelay = 4;
    private int spawnRateLevel = -1;
    private float[] spawnRates = {5f, 4f, 3.5f};
    private float horizontalRange = 10;
    private float verticalRange = 10;
    private float zStart = 50;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IncreaseSpawnRate();
    }

    public void IncreaseSpawnRate()
    {
        if (spawnRateLevel == spawnRates.Length - 1)
        {
            return;
        }
        else
        {
            spawnRateLevel++;
            Debug.Log("Spawn delay now " + spawnRates[spawnRateLevel]);
            CancelInvoke();
            InvokeRepeating("SpawnTarget", startDelay, spawnRates[spawnRateLevel]);
        }
    }

    void SpawnTarget()
    {
        float spawnX = Random.Range(-horizontalRange, horizontalRange);
        float spawnY = Random.Range(-verticalRange + 3, verticalRange);
        Instantiate(targetPrefab, new Vector3(spawnX, spawnY, zStart), targetPrefab.transform.rotation);
    }
}
