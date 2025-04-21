using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged; // subscribe to the OnStateChanged event of GameManager
        Hide(); // hide the countdown UI at the start
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccesfulRecipesAmount().ToString();
        }
        else
        {
            Hide();
        }
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
