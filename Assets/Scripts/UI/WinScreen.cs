using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Button restartButton;

    private void Awake()
    {
        Debug.Log($"[WinScreen] Awake() - name={gameObject.name}, activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
    }

    private void Start()
    {
        Debug.Log($"[WinScreen] Start() - name={gameObject.name}, activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
        gameObject.SetActive(false);
        Debug.Log($"[WinScreen] Start() - After SetActive(false), activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartClicked);
            Debug.Log("[WinScreen] Restart button listener added");
        }
        else
        {
            Debug.LogWarning("[WinScreen] restartButton is NULL!");
        }
    }

    public void Show()
    {
        Debug.Log($"[WinScreen] Show() called! name={gameObject.name}, activeSelf before={gameObject.activeSelf}");
        gameObject.SetActive(true);
        Debug.Log($"[WinScreen] Show() - After SetActive(true), activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnRestartClicked()
    {
        Debug.Log("[WinScreen] Restart button clicked!");
        GameManager.Instance.RestartGame();
    }
}