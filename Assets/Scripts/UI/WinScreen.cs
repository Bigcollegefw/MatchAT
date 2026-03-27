using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Button restartButton;
    private bool gameEnded = false;

    private void Awake()
    {
        Debug.Log($"[WinScreen] Awake()");
    }

    private void Start()
    {
        Debug.Log($"[WinScreen] Start() - gameEnded={gameEnded}");
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
        Debug.Log($"[WinScreen] Show() called!");
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
        Debug.Log("[WinScreen] Restart clicked!");
        GameManager.Instance.RestartGame();
    }
}