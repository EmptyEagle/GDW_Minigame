using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3.5f;
    private ApplyPowerups applyPowerups;
    private int powerupIndex;
    private bool isRightSpawning;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        applyPowerups = GameObject.Find("Cannon").GetComponent<ApplyPowerups>();
        switch (gameObject.tag)
        {
            case "Powerup_Speed":
                powerupIndex = 0;
                break;
            case "Powerup_DoubleLaunch":
                powerupIndex = 1;
                break;
            case "Powerup_QuickReload":
                powerupIndex = 2;
                break;
        }
        if (transform.position.x > 0)
        {
            speed = -speed;
            isRightSpawning = true;
        }
        else
        {
            isRightSpawning = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (applyPowerups.CheckPowerup(powerupIndex))
        {
            Destroy(gameObject);
        }

        if (isRightSpawning && transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        else if (!isRightSpawning && transform.position.x > 50)
        {
            Destroy(gameObject);
        }
    }
}
