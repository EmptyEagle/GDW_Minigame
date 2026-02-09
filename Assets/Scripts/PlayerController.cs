using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed;
    public float maxRangeHorizontal = 50;
    public float maxRangeVertical = 50;
    private bool canFire = true;
    public GameObject projectilePrefab;
    public AudioSource cannonLaunchSound;
    public AudioSource cannonReloadSound;
    
    // Update is called once per frame
    void Update()
    {
        // Player rotation
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * verticalInput * turnSpeed * Time.deltaTime);
        //Debug.Log("Local angle: "+transform.localEulerAngles);
        //Debug.Log("World angle: "+transform.eulerAngles);
        if (transform.localEulerAngles.y > maxRangeHorizontal && transform.localEulerAngles.y < 180)
        {
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, maxRangeHorizontal, 0);
        }
        else if (transform.localEulerAngles.y < 360 - maxRangeHorizontal  && transform.localEulerAngles.y > 180)
        {
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, -maxRangeHorizontal, 0);
        }
        if (transform.localEulerAngles.x > maxRangeVertical && transform.localEulerAngles.x < 180)
        {
            transform.eulerAngles = new Vector3(maxRangeVertical, transform.localEulerAngles.y, 0);
        }
        else if (transform.localEulerAngles.x < 360 - maxRangeVertical && transform.localEulerAngles.x > 180)
        {
            transform.eulerAngles = new Vector3(-maxRangeVertical, transform.localEulerAngles.y, 0);
        }
        
        // Player firing projectiles
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && canFire)
        {
            StartCoroutine(FireProjectile());
        }
    }

    IEnumerator FireProjectile()
    {
        canFire = false;
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        cannonLaunchSound.Play();
        yield return new WaitForSeconds(2);
        canFire = true;
        cannonReloadSound.Play();
    }
}
