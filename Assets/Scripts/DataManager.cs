using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LeaderboardEntry
{
    public string Username;
    public int Score;
}

[System.Serializable]
public class Leaderboard
{
    public List<LeaderboardEntry> Entries = new();

    private int m_MaxEntries = 5;

    public void AddEntry(string username, int score)
    {
        var entry = new LeaderboardEntry
        {
            Username = username,
            Score = score
        };
        Entries.Add(entry);

        Entries.Sort((a, b) => b.Score.CompareTo(a.Score));

        if (Entries.Count > m_MaxEntries)
        {
            Entries.RemoveAt(Entries.Count - 1);
        }
    }
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username = "Anonimus";

    public Leaderboard Leaderboard = new();

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

    public void SaveScore()
    {
        string json = JsonUtility.ToJson(Leaderboard);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Leaderboard = JsonUtility.FromJson<Leaderboard>(json);
        }
    }
}
