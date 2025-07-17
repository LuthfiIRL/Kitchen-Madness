using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // singleton instance of GameManager   

    public event EventHandler OnStateChanged; // event to notify when the game state changes
    public event EventHandler OnGamePaused; // event to notify when the game is paused
    public event EventHandler OnGameUnpaused; // event to notify when the game is unpaused
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    } // enum State for game states

    private State state; // current state of the game
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;
    private bool isGamePaused = false; // flag to check if the game is paused

    private void Awake()
    {
        Instance = this; // set the singleton instance
        state = State.WaitingToStart; // initialize state to WaitingToStart        
    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction; // subscribe to pause action event
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart; // transition to CountdownToStart state
                    OnStateChanged?.Invoke(this, EventArgs.Empty); // notify subscribers of state change
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying; // transition to GamePlaying state 
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty); // notify subscribers of state change
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty); // notify subscribers of state change
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state); // log the current state
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying; // check if the game is currently playing
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart; // check if the countdown to start is active
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer; // get the remaining time for the countdown to start
    }

    public bool IsGameOver()
    {
        return state == State.GameOver; // check if the game is over
    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax); // get the normalized game playing timer
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused; // toggle the pause state
        if (isGamePaused)
        {
            Time.timeScale = 0f; // pause the game by setting time scale to 0
            OnGamePaused?.Invoke(this, EventArgs.Empty); // notify subscribers that the game is paused
        }
        else
        {
            Time.timeScale = 1f; // resume the game by setting time scale to 1
            OnGameUnpaused?.Invoke(this, EventArgs.Empty); // notify subscribers that the game is unpaused
        }       
    }
}
