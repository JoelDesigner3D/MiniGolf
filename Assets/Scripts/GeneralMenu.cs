using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralMenu : MonoBehaviour
{

    [SerializeField] AudioSource music;


    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

}
