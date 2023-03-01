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
        }

        if (other.gameObject.tag == "Win")
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextLevel < 10)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }

}
