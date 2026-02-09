using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour
{
    public Button retryButton;

    void Start()
    {
        retryButton.onClick.AddListener(OnRetry);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            OnRetry();
        }
    }

    void OnRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
