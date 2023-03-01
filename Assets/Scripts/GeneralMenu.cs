using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralMenu : MonoBehaviour
{

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

}
