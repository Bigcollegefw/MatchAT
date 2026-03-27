using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public Button restartButton;
    private bool gameEnded = false;

    private void Awake()
    {
        Debug.Log($"[LoseScreen] Awake()");
    }

    private void Start()
    {
        Debug.Log($"[LoseScreen] Start() - gameEnded={gameEnded}");
        if (!gameEnded)
        {
            gameObject.SetActive(false);
        }
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartClicked);
        }
    }

    public void Show()
    {
        Debug.Log($"[LoseScreen] Show() called!");
        gameEnded = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameEnded = false;
        gameObject.SetActive(false);
    }

    private void OnRestartClicked()
    {
        Debug.Log("[LoseScreen] Restart clicked!");
        GameManager.Instance.RestartGame();
    }
}