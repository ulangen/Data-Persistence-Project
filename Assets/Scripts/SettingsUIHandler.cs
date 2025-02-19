using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;

    public Button SaveButton;
    public Text SaveButtonText;

    AudioManager m_AudioManager;
    bool m_IsDataLoaded = false;

    void Start()
    {
        m_AudioManager = AudioManager.Instance;

        if (m_AudioManager != null && m_AudioManager.AudioData != null)
        {
            // Установка значений регуляторов громкости из настроек
            MasterVolumeSlider.value = m_AudioManager.AudioData.MasterVolume;
            MusicVolumeSlider.value = m_AudioManager.AudioData.MusicVolume;
            m_IsDataLoaded = true;

            if (m_AudioManager.HasDataChanged)
            {
                OnDataChanged();
            }
            else
            {
                DisableSaveButton();
            }
        }
        else
        {
            DisableSaveButton();
        }
    }

    void OnDataChanged()
    {
        SaveButton.interactable = true;
        SaveButtonText.text = "*Save";
    }

    void DisableSaveButton()
    {
        SaveButton.interactable = false;
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("menu");
    }

    public void OnSaveButtonClicked()
    {
        if (m_AudioManager != null)
        {
            m_AudioManager.Save();
            SaveButtonText.text = "Save";
            SaveButton.interactable = false;
        }
    }

    public void OnMasterVolumeSliderChanged(float volume)
    {
        if (m_AudioManager != null && m_IsDataLoaded)
        {
            m_AudioManager.SetMasterVolume(volume);
            OnDataChanged();
        }
    }

    public void OnMusicVolumeSliderChanged(float volume)
    {
        if (m_AudioManager != null && m_IsDataLoaded)
        {
            m_AudioManager.SetMusicVolume(volume);
            OnDataChanged();
        }
    }
}
