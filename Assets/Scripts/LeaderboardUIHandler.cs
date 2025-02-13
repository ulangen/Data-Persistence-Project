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
