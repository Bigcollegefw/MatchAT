using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    public GameConfig gameConfig;
    public GameManager gameManager;

    float timeRemaining;

    void Start()
    {
        timeRemaining = gameConfig.gameDuration;
    }

    void Update()
    {
        if (gameManager != null && gameManager.IsGameRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Max(0, timeRemaining);

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            if (timerText != null)
            {
                timerText.text = $"{minutes:00}:{seconds:00}";
            }

            if (timeRemaining <= 0)
            {
                gameManager.EndGame(false);
            }
        }
    }
}
