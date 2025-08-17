using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();
        }); 

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene); // Load the main menu scene
        });    

        optionsButton.onClick.AddListener(() =>
        {
            OptionsUI.Instance.Show();
        });       
    }
    private void Start()
    {
        GameManager.Instance.OnGamePaused += Gamemanager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += Gamemanager_OnGameUnpaused;

        Hide(); // Initially hide the pause UI
    }

    private void Gamemanager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show(); 
    }

    private void Gamemanager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide(); 
    }
    private void Show()
    {
        gameObject.SetActive(true); // Show the pause UI
    }

    private void Hide()
    {
        gameObject.SetActive(false); // Hide the pause UI
    }
}
