using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public Button restartButton;
    private int startCallCount = 0;

    private void Awake()
    {
        Debug.Log($"[LoseScreen] Awake() - name={gameObject.name}, instanceID={GetInstanceID()}, activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
    }

    private void Start()
    {
        startCallCount++;
        Debug.Log($"[LoseScreen] Start() #{startCallCount} - name={gameObject.name}, instanceID={GetInstanceID()}, activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
        gameObject.SetActive(false);
        Debug.Log($"[LoseScreen] Start() - After SetActive(false), activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartClicked);
            Debug.Log("[LoseScreen] Restart button listener added");
        }
        else
        {
            Debug.LogWarning("[LoseScreen] restartButton is NULL!");
        }
    }

    public void Show()
    {
        Debug.Log($"[LoseScreen] Show() called! name={gameObject.name}, instanceID={GetInstanceID()}, activeSelf before={gameObject.activeSelf}");
        gameObject.SetActive(true);
        Debug.Log($"[LoseScreen] Show() - After SetActive(true), activeInHierarchy={gameObject.activeInHierarchy}, activeSelf={gameObject.activeSelf}");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnRestartClicked()
    {
        Debug.Log("[LoseScreen] Restart button clicked!");
        GameManager.Instance.RestartGame();
    }
}