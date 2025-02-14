using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardUIHandler : MonoBehaviour
{
    public List<Text> LeaderboardTextItems;
    public Text ErrorMessage;

    private void Start()
    {
        if (DataManager.Instance == null)
        {
            ShowLoadDataError();
            return;
        }

        int count = Mathf.Min(LeaderboardTextItems.Count, DataManager.Instance.Leaderboard.Entries.Count);
        for (int i = 0; i < count; i++)
        {
            Text item = LeaderboardTextItems[i];
            LeaderboardEntry entry = DataManager.Instance.Leaderboard.Entries[i];

            item.text = $"{entry.Username} : {entry.Score}";
            item.gameObject.SetActive(true);
        }
    }

    private void ShowLoadDataError()
    {
        ErrorMessage.gameObject.SetActive(true);
        ErrorMessage.text = "Oops... Filed to load data.";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
