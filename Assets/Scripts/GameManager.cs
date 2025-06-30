using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // singleton instance of GameManager   

    public event EventHandler OnStateChanged; // event to notify when the game state changes
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
}
