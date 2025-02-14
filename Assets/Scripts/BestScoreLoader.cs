using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreLoader : MonoBehaviour
{
    public Text BestScoreText;

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (DataManager.Instance != null)
        {
            Leaderboard leaderboard = DataManager.Instance.Leaderboard;

            if (leaderboard.Entries.Count == 0)
            {
                BestScoreText.text = "No one has played the game yet.";
                return;
            }

            LeaderboardEntry firstEntry = leaderboard.Entries[0];
            BestScoreText.text = $"Best Score : {firstEntry.Username} : {firstEntry.Score}";
            return;
        }

        BestScoreText.text = "Filed to load data.";
    }
}
