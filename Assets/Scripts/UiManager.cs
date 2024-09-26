using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Buttons")]
    
    [SerializeField] private Button settingsButton; 
    [SerializeField] private Button playButton;
    
    [Header("Sliders")]
    
    [SerializeField] private Slider musicSlider; 
    [SerializeField] private Slider effectSlider; 
    
    [Header("GameObjects References")]
    
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private AudioManager audioManager;


    private void Start()
    {
        StopTime();
        //BOTONES
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        
        //SLIDERS
        musicSlider.onValueChanged.AddListener(OnChangeMusicVolume);
        effectSlider.onValueChanged.AddListener(OnChangeEffectVolume);
    }


    private void OnDestroy()
    {
        settingsButton.onClick.RemoveAllListeners();
        playButton.onClick.RemoveAllListeners();
    }
    
    private void OnPlayButtonClicked()
    {
        PlayTime();
        panelMenu.SetActive(false);
    }
    
    private void OnSettingsButtonClicked()
    {
        panelSettings.SetActive(true);
    }

    private void OnChangeMusicVolume(float volume)
    {
        musicSlider.value = volume;
        audioManager.SetMusicVolume(volume);
    }
    private void OnChangeEffectVolume(float volume)
    {
        effectSlider.value = volume;
        audioManager.SetEffectVolume(volume);
    }
    
    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void PlayTime()
    {
        Time.timeScale = 1;
    }
}
