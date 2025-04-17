using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText; // reference to the countdown text UI element

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged; // subscribe to the OnStateChanged event of GameManager
        Hide(); // hide the countdown UI at the start
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        countdownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void Show()
    {
        gameObject.SetActive(true); // activate the countdown UI
    }

    private void Hide()
    {
        gameObject.SetActive(false); // deactivate the countdown UI
    }
}
