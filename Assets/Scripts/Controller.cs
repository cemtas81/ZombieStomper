using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float worldWidth = 7;  //serialized, example value
    float ratioScreenToWorld = 1.0f; //serialized, example value

    float screenWidth = (float)Screen.width;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
            rb.velocity = new Vector3(-4, 0, 0);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float horizontal = touch.deltaPosition.x;
                Debug.Log(horizontal);
                    transform.position +=
                          new Vector3(0f, 0f, (horizontal * (worldWidth / screenWidth) * ratioScreenToWorld) / 4);
                
                //clamp, or whatever
            }
        }
    }

}
