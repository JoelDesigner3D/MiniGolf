using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreField;


    public void SetScore(int score)
    {
        scoreField.text = "Score : " + score;
    }


    public void GoToGeneralMenu()
    {
        GameManager.Instance.GoToGeneralMenu();
    }


    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

}
