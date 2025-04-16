using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // singleton instance of GameManager    
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
    private float gamePlayingTimer = 10f;

    private void Awake()
    {
        Instance = this; // set the singleton instance
        state = State.WaitingToStart; // initialize state to WaitingToStart        
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
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying; // transition to GamePlaying state 
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver; 
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
}
