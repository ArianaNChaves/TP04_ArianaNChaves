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


    private void Start()
    {
        StopTime();
        AudioManager.Instance.PlayMusic("Main Music");
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
        if (panelSettings.activeSelf)
        {
            panelSettings.SetActive(false); 
        }
        else
        {
            panelSettings.SetActive(true);
        }
    }

    private void OnChangeMusicVolume(float volume)
    {
        AudioManager.Instance.MusicVolume(volume);
    }
    private void OnChangeEffectVolume(float volume)
    {
        AudioManager.Instance.SfxVolume(volume);
        AudioManager.Instance.PlayEffect("Hit Sound");
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
