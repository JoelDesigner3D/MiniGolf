using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI strokesCountText;
    [SerializeField] ShotButtonController shotButtonController;
    [SerializeField] GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

           // SFXController.Instance.PlaySoundById(4);  //respown
        }

        if (other.gameObject.tag == "Border")
        {
            SFXController.Instance.PlaySoundById(2); //border SFX
        }

        if (other.gameObject.tag == "Win")
        {
            int strokes = shotButtonController.nbShots;

            int levelScore = (10 - strokes);
            if (levelScore < 0)
            {
                levelScore = 0;
            }
            GameManager.Instance.score += levelScore;

            if (strokes == 1)
            {
                strokesCountText.text = "Terminé en 1 coup, bravo !";
            }
            else
            {
                strokesCountText.text = "Terminé en " + strokes + " coups !";
            }
            

            SFXController.Instance.PlaySoundById(1);

            StartCoroutine("LoadLevelMenuAfterSeconds", gameManager);            
        }
    }


    IEnumerator LoadLevelMenuAfterSeconds(GameManager gameManager)
    {
        yield return new WaitForSeconds(3);

        gameManager.DisplayLevelMenu();

    }


}
