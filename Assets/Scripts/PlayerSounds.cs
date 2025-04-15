using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player; // Reference to the Player component
    private float footstepTimer; // Timer for footstep sound
    private float footstepTimerMax = 0.1f; // Maximum time between footstep sounds

    private void Awake()
    {
        player = GetComponent<Player>(); // Get the Player component attached to this GameObject
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime; // Decrease the footstep timer by the time since the last frame

        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax; // Reset the footstep timer

            if (player.IsWalking()) // Check if the player is walking
            {
                float volume = 1F; // Volume of the footstep sound
                SoundManager.Instance.PlayFootstepSound(player.transform.position, volume); // Play the footstep sound                   
            }                     
        }
    }
}
