using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardUIHandler : MonoBehaviour
{
    public List<Text> m_LeaderboardTextItems;

    private void Start()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
