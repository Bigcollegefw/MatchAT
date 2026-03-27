using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool IsGameRunning { get; private set; }
    public bool HasWon { get; private set; }

    public GameConfig gameConfig;
    public WinScreen winScreen;
    public LoseScreen loseScreen;
    public TimerDisplay timerDisplay;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        IsGameRunning = true;
        HasWon = false;

        if (winScreen != null) winScreen.Hide();
        if (loseScreen != null) loseScreen.Hide();

        ScoreManager.Instance.ResetScore();
        GridManager.Instance.ResetGrid();
        if (timerDisplay != null) timerDisplay.ResetTimer();
    }

    public void CheckWinCondition()
    {
        if (!IsGameRunning) return;

        if (ScoreManager.Instance.HasReachedTarget())
        {
            EndGame(true);
        }
    }

    public void EndGame(bool won)
    {
        Debug.Log($"[GameManager] EndGame({won}) called. loseScreen={loseScreen}");
        IsGameRunning = false;
        HasWon = won;

        if (won)
        {
            if (winScreen != null) winScreen.Show();
        }
        else
        {
            if (loseScreen != null)
            {
                Debug.Log("[GameManager] Calling loseScreen.Show()");
                loseScreen.Show();
            }
            else
            {
                Debug.LogError("[GameManager] loseScreen is NULL!");
            }
        }
    }

    public void RestartGame()
    {
        StartGame();
    }
}
