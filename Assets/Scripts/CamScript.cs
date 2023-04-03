using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamScript : MonoBehaviour
{

    public GameObject ball;
    public float distance = 3.5f;

    public float posVerticale = 2f;

    public float posX = 0.5f;
    public float posY = 0.5f;
    private Quaternion rotation;
    private Touch touch;   // Ecran tactile

    // Start is called before the first frame update
    void Start()
    {
        posX = transform.eulerAngles.y;
        posY = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {

// si on est sur PC

    #if UNITY_EDITOR || UNITY_STANDALONE

        posX += Input.GetAxis("Mouse X") * 3;

    #endif

       // si on est sur mobile
    #if UNITY_ANDROID || UNITY_IPHONE

        if(Input.touches.Length == 1)
        {
            posX += Input.GetTouch(0).deltaPosition.x * 0.1f;
        }

    #endif 

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            rotation = Quaternion.Euler(posY, posX, 0f);
        }

        Vector3 position = rotation * new Vector3(0f, ball.transform.position.y / 3 + posVerticale, -distance) + ball.transform.position;

        transform.position = position;
        transform.rotation = rotation;

        if (transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }

    }
}
