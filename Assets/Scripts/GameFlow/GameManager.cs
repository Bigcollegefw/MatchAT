using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameRunning { get; private set; }
    public bool HasWon { get; private set; }

    public GameConfig gameConfig;
    public GameObject winScreen;
    public GameObject loseScreen;

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

        if (winScreen != null) winScreen.SetActive(false);
        if (loseScreen != null) loseScreen.SetActive(false);
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
            if (winScreen != null) winScreen.SetActive(true);
        }
        else
        {
            if (loseScreen != null) loseScreen.SetActive(true);
        }
    }
}
