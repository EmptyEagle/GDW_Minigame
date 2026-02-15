using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatManager : MonoBehaviour
{
    private int playerHealth;
    private int playerScore;
	public Text textHealth;
	public Text textScore;
    public GameObject gameOverCanvas;
    public GameObject damageVignette;

	void Start()
    {
        gameOverCanvas.SetActive(false);
        damageVignette.SetActive(false);
        playerHealth = 25;
        textHealth.text = "Health: "+playerHealth;
        playerScore = 0;
        textScore.text = "Score: "+playerScore;
    }

    public void DamagePlayer()
    {
        playerHealth--;
		textHealth.text = "Health: "+playerHealth;
        StartCoroutine(DamageVignette());
        if (playerHealth <= 0)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator DamageVignette()
    {
        damageVignette.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageVignette.SetActive(false);
    }

    public void AddScore()
    {
        playerScore++;
		textScore.text = "Score: "+playerScore;
        Debug.Log("Score: "+playerScore);
    }
}
