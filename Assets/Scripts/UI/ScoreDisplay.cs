using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        if (ScoreManager.Instance != null && scoreText != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.CurrentScore} / {ScoreManager.Instance.TargetScore}";
        }
    }
}
