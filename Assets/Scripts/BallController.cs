using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI strokesCountText;
    [SerializeField] ShotButtonController shotButtonController;


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

            int score = (10 - strokes) * 100;
            if (score < 0)
            {
                score = 0;
            }
            GameManager.Instance.score += score;

            if (strokes == 1)
            {
                strokesCountText.text = "Terminé en 1 coup, bravo !";
            }
            else
            {
                strokesCountText.text = "Terminé en " + strokes + " coups !";
            }
            

            SFXController.Instance.PlaySoundById(1);

            StartCoroutine("LoadLevelAfterSeconds");            
        }
    }

    IEnumerator LoadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(3);

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

}
