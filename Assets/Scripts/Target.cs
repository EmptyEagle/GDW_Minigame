using UnityEngine;

public class Target : MonoBehaviour
{
    private static int numSpawned;
    private float speed;
    public float speedFirst = 4f;
    public float speedSecond = 6f;
    public float speedThird = 7f;
    private float zStop = 15;
    public Material dangerZoneMaterial;
    private bool isDangerZone;
    private float fireDelay = 0.5f;
    private float fireRate = 1;
    private StatManager manager;

    void Start()
    {
        manager = GameObject.Find("StatManager").GetComponent<StatManager>();
        
        numSpawned++;
        //Debug.Log("Spawned: "+ numSpawned);

        if (numSpawned > 15)
        {
            speed = speedThird;
            //Debug.Log("Level 3");
        }
        else if (numSpawned > 6)
        {
            speed = speedSecond;
            //Debug.Log("Level 2");
        }
        else
        {
            speed = speedFirst;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zStop)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (!isDangerZone)
        {
            GetComponent<Renderer>().material = dangerZoneMaterial;
            InvokeRepeating("FireAtPlayer", fireDelay, fireRate);
            isDangerZone = true;
        }
        if (isDangerZone)
        {
            // Anything that happens when the target is in position
        }
    }

    void FireAtPlayer()
    {
        manager.DamagePlayer();
    }
}
