using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username = "Anonimus";
    public int ScorePoints = -1;
    public string LoadedUsername = "";
    public int LoadedScorePoints = -1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string Username;
        public int ScorePoints;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Username = Username;
        data.ScorePoints = ScorePoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LoadedUsername = data.Username;
            LoadedScorePoints = data.ScorePoints;
        }
    }
}
