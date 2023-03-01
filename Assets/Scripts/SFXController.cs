using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{

    [SerializeField] AudioClip[] sfx;
    [SerializeField] AudioSource audioSource;

    public static SFXController _instance;

    public static SFXController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SFXController>();
            }
            return _instance;
        }
    }

    public void PlaySoundById(int id)
    {
        audioSource.PlayOneShot(sfx[id]);
    }

}
