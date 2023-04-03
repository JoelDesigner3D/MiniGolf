using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
    using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int score = 0;

    [SerializeField] EndLevelManager endLevelManager;
    [SerializeField] Canvas endLevelMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        Debug.Log("=========  NEW GAME ==========");
        endLevelMenu.enabled = false;
    }


    public void DisplayLevelMenu()
    {
        Debug.Log("=========  End Level ==========");
        Debug.Log("Score = "+ score);
        endLevelMenu.enabled = true;
        endLevelManager.SetScore(score);
    }


    public void  NextLevel()
    {
        Debug.Log("=========  Next Level ==========");

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        //int scenesCount = SceneManager.sceneCount;

        if (nextLevel < 3)
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GoToGeneralMenu()
    {
        SceneManager.LoadScene(0);
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
