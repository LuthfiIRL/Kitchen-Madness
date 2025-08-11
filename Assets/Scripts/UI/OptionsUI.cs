using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;

    private void Awake()
    {
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
        });

        musicButton.onClick.AddListener(() =>
        {

        });
    }

    private void UpdateVisual()
    {
        
    }
}
