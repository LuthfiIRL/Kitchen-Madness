using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter; // Reference to the StoveCounter component
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged; // Subscribe to the OnStateChanged event of the StoveCounter
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if (playSound)
        {
            audioSource.Play(); // Play the sound when the stove is frying or fried
        }
        else
        {
            audioSource.Pause(); // Pause the sound when the stove is idle or burned
        }
    }
}
