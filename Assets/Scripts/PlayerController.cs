using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed;
    public float maxRangeHorizontal = 50;
    public float maxRangeVertical = 50;
    
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * verticalInput * turnSpeed * Time.deltaTime);
        Debug.Log("Local angle: "+transform.localEulerAngles);
        Debug.Log("World angle: "+transform.eulerAngles);
        if (transform.localEulerAngles.y > maxRangeHorizontal && transform.localEulerAngles.y < 180)
        {
            Debug.Log("Exceeded right bounds");
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, maxRangeHorizontal, 0);
        }
        else if (transform.localEulerAngles.y < 360 - maxRangeHorizontal  && transform.localEulerAngles.y > 180)
        {
            Debug.Log("Exceeded left bounds");
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, -maxRangeHorizontal, 0);
        }
        if (transform.localEulerAngles.x > maxRangeVertical && transform.localEulerAngles.x < 180)
        {
            Debug.Log("Exceeded bottom bounds");
            transform.eulerAngles = new Vector3(maxRangeVertical, transform.localEulerAngles.y, 0);
        }
        else if (transform.localEulerAngles.x < 360 - maxRangeVertical && transform.localEulerAngles.x > 180)
        {
            Debug.Log("Exceeded top bounds");
            transform.eulerAngles = new Vector3(-maxRangeVertical, transform.localEulerAngles.y, 0);
        }
    }
}
