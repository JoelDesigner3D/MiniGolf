using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    

    public static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    //================================================================

    public int score = 0;

    [SerializeField] EndLevelManager endLevelManager;
    [SerializeField] Canvas endLevelMenu;

    // Start is called before the first frame update
    void Start()
    {
        endLevelMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayLevelMenu()
    {
        endLevelMenu.enabled = true;
        endLevelManager.SetScore(score);

    }


    public void  NextLevel()
    {
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

}
