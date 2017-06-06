using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;

    private void Awake()
    {
        if (MainMenuController.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SwitchScene("Main Menu");
        }
    }

    public void OnPlay()
    {
        SwitchScene("Game Scene");
    }

    public void OnEdit()
    {
        SwitchScene("Edit Map");
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SwitchScene(string name)
    {
        string current = SceneManager.GetActiveScene().name;

        if (current == name)
        {
            return;
        }

        SceneManager.UnloadSceneAsync(current);
        SceneManager.LoadScene(name);
    }
}