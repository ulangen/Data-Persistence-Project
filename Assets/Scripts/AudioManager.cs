using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioData
{
    public float MasterVolume = 1.0f;
    public float MusicVolume = 1.0f;
    public bool IsMuted = false;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioData AudioData;
    public AudioMixer MainAudioMixer;
    public bool HasDataChanged = false;

    bool m_IsDataLoaded = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (DataManager.Instance != null)
        {
            AudioData = DataManager.Instance.Settings.AudioData;

            // Применение громкости звуков из настроек
            if (AudioData.IsMuted)
            {
                SetMasterVolume(0);
            }
            else
            {
                SetMasterVolume(AudioData.MasterVolume);
                SetMusicVolume(AudioData.MusicVolume);
            }
            m_IsDataLoaded = true;
        }
    }

    float LinearVolumeToDB(float volume)
    {
        if (volume <= 0)
        {
            return -80.0f;
        }
        else
        {
            return Mathf.Log10(volume) * 20.0f;
        }
    }

    public void SetMute(bool isMuted)
    {
        if (AudioData != null)
        {
            // Изменение главного уровня громкости
            float volumeDB = isMuted ? LinearVolumeToDB(0) : LinearVolumeToDB(AudioData.MasterVolume);
            MainAudioMixer.SetFloat("MasterVolumeLevel", volumeDB);

            if (m_IsDataLoaded)
            {
                // Изменение локльных настроек громкости
                AudioData.IsMuted = isMuted;
                HasDataChanged = true;
            }
        }
    }

    public void SetMasterVolume(float volume)
    {
        if (AudioData != null)
        {
            // Изменение главного уровня громкости
            float volumeDB = LinearVolumeToDB(volume);
            MainAudioMixer.SetFloat("MasterVolumeLevel", volumeDB);

            if (m_IsDataLoaded)
            {
                // Изменение локльных настроек громкости
                AudioData.MasterVolume = volume;
                HasDataChanged = true;
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioData != null)
        {
            // Изменение уровня громкости музыки
            float volumeDB = LinearVolumeToDB(volume);
            MainAudioMixer.SetFloat("MusicVolumeLevel", volumeDB);

            if (m_IsDataLoaded)
            {
                // Изменение локальных настроек громкости
                AudioData.MusicVolume = volume;
                HasDataChanged = true;
            }
        }
    }

    public void Save()
    {
        if (DataManager.Instance != null)
        {
            // Сохранение настроек громкости
            DataManager.Instance.SaveSettings();
            HasDataChanged = false;
        }
    }
}
