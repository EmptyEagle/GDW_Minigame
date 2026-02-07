using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    private float startDelay = 4;
    private float spawnRate = 5;
    private float horizontalRange = 10;
    private float verticalRange = 10;
    private float zStart = 50;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnTarget", startDelay, spawnRate);
    }

    void SpawnTarget()
    {
        float spawnX = Random.Range(-horizontalRange, horizontalRange);
        float spawnY = Random.Range(-verticalRange + 3, verticalRange);
        Instantiate(targetPrefab, new Vector3(spawnX, spawnY, zStart), targetPrefab.transform.rotation);
    }
}
