using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField Username;

    void Start()
    {
        Username.text = DataManager.Instance.Username;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void SetUsername(string username)
    {
        DataManager.Instance.Username = username;
    }
}
