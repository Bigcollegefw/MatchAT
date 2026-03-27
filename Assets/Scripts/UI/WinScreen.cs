using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        gameObject.SetActive(false);
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartClicked);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnRestartClicked()
    {
        GameManager.Instance.RestartGame();
    }
}