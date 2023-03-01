using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class ShotButtonController : MonoBehaviour
{

    [SerializeField] RectTransform powerBar;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject guide;

    bool powerActivated = false;
    bool canShot = true;
    bool canCheckSpeed = false;
    int nbShots = 0;

    [SerializeField] int speed = 2000;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            HandleShot();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
        {
            HandleShot();
        }

        if (ball.GetComponent<Rigidbody>().velocity.magnitude < 0.2f && canCheckSpeed)
        {
            canShot = true;
        }
    }


    public void HandleShot()
    {
        if (canShot)
        {
            if (!powerActivated)
            { 
                guide.SetActive(true);
                ActivatePowerBar();
            }
            else
            { 
                canShot = false;
                ShotTheBall();
                SFXController.Instance.PlaySoundById(0);
                guide.SetActive(false);
            }
        }
        
    }

    public void ActivatePowerBar()
    {
        powerActivated = true;
        StartCoroutine("AnimatePowerBar");
    }

    public void ShotTheBall()
    {
        powerActivated = false;
        nbShots++;
        StopAllCoroutines();

        float shotPower = powerBar.localScale.x * speed;

        Vector3 force = Camera.main.transform.forward * shotPower;

        ball.GetComponent<Rigidbody>().AddForce(force);

        StartCoroutine("ActivateSpeedCheck");

    }

    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1);
        canCheckSpeed = true;
    }


    IEnumerator AnimatePowerBar()
    {
        float val = 0.1f;
        while (powerActivated)
        {
            yield return new WaitForSeconds(0.05f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y, powerBar.localScale.z);

            if (powerBar.localScale.x <= 0.05f)
            {
                val = -0.05f;
            }
            if (powerBar.localScale.x >= 1f)
            {
                val = 0.05f;
            }
        }
    }
    
}
