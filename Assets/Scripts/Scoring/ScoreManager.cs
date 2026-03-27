using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int CurrentScore { get; private set; }
    public int TargetScore => gameConfig.targetScore;

    public Text scoreText;
    public GameConfig gameConfig;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CurrentScore = 0;
        UpdateDisplay();
    }

    public void AddScore(int points)
    {
        CurrentScore += points;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {CurrentScore} / {TargetScore}";
        }
    }

    public bool HasReachedTarget()
    {
        return CurrentScore >= TargetScore;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UpdateDisplay();
    }
}
