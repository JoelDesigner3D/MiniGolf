using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

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
            SFXController.Instance.PlaySoundById(1);

            StartCoroutine("LoadLevelAfterSeconds");            
        }
    }

    IEnumerator LoadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(3);

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        //if (nextLevel < 10)
        //{
        //    SceneManager.LoadScene(nextLevel);
       // }
       // else
       // {
            SceneManager.LoadScene(0);
       // }
    }

}
