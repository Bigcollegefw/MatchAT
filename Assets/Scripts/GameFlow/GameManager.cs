using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool IsGameRunning { get; private set; }
    public bool HasWon { get; private set; }

    public GameConfig gameConfig;
    public WinScreen winScreen;
    public LoseScreen loseScreen;

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
        IsGameRunning = false;
        HasWon = won;

        if (won)
        {
            if (winScreen != null) winScreen.Show();
        }
        else
        {
            if (loseScreen != null) loseScreen.Show();
        }
    }
}
