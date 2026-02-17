using System.Runtime.CompilerServices;
using UnityEngine;

public class Target : MonoBehaviour
{
    private static int numSpawned;
    private float speed;
    private float speedFirst = 4f;
    private float speedSecond = 5.3f;
    private float speedThird = 6.5f;
    private float speedFourth = 7f;
    private float speedFifth = 7.3f;
    private float zStop = 15;
    public Material dangerZoneMaterial;
    private bool isDangerZone;
    private float fireDelay = 0.5f;
    private float damageDelay = 0.25f;
    private StatManager manager;
    private AudioSource targetFireSound;
    private TargetSpawner targetSpawner;

    void Start()
    {
        manager = GameObject.Find("StatManager").GetComponent<StatManager>();
        targetFireSound = GameObject.Find("TargetFireSound").GetComponent<AudioSource>();
        targetSpawner = GameObject.Find("TargetSpawner").GetComponent<TargetSpawner>();
        
        numSpawned++;
        //Debug.Log("Spawned: "+ numSpawned);

        // Increasing spawn rate of targets
        if (numSpawned == 11 || numSpawned == 19 || numSpawned == 26 || numSpawned == 33 || numSpawned == 40 || numSpawned == 56)
        {
            targetSpawner.IncreaseSpawnRate();
        }

        // Increasing speed of targets
        if (numSpawned > 58)
        {
            speed = speedFifth;
            //Debug.Log("Level 5");
        }
        else if (numSpawned > 32)
        {
            speed = speedFourth;
            //Debug.Log("Level 4");
        }
        else if (numSpawned > 15)
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
            //Debug.Log("Level 1");
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
            InvokeRepeating("FireAtPlayer", fireDelay, damageDelay);
            isDangerZone = true;
        }
        if (isDangerZone)
        {
            // Anything that happens when the target is in position
        }
    }

    void FireAtPlayer()
    {
        targetFireSound.Play();
        manager.DamagePlayer();
    }
}
