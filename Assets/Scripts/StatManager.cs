using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    private int playerHealth;
    private int playerScore;
	public Text textHealth;
	public Text textScore;
    public GameObject gameOverCanvas;

	void Start()
    {
        gameOverCanvas.SetActive(false);
        playerHealth = 3;
        textHealth.text = "Health: "+playerHealth;
        playerScore = 0;
        textScore.text = "Score: "+playerScore;
    }

    public void DamagePlayer()
    {
        playerHealth--;
		textHealth.text = "Health: "+playerHealth;
        if (playerHealth <= 0)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddScore()
    {
        playerScore++;
		textScore.text = "Score: "+playerScore;
        Debug.Log("Score: "+playerScore);
    }
}
