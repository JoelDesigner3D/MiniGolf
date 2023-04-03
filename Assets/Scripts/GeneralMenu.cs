using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GeneralMenu : MonoBehaviour
{

    [SerializeField] AudioSource music;


    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("=========  QUIT GAME ==========");
        //SavePlayerPrefs();  // TODO

#if UNITY_EDITOR
        //EditorApplication.ExecuteMenuItem("Edit/Play");
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}
