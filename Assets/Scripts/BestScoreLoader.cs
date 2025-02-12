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
            if (DataManager.Instance.LoadedScorePoints == -1)
            {
                BestScoreText.text = "No one has played the game yet.";
                return;
            }

            BestScoreText.text = $"Best Score : {DataManager.Instance.LoadedUsername} : {DataManager.Instance.LoadedScorePoints}";
            return;
        }

        BestScoreText.text = "Filed to load data.";
    }
}
