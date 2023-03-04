using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    [SerializeField] CanvasRenderer pauseBackground;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBackground.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {

        if (paused == false)
        {
            pauseBackground.gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            pauseBackground.gameObject.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
        
    }

}
