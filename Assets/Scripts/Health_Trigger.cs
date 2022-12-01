using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
       
            GameObject.Find("FillBar_In").GetComponent<Image>().fillAmount += 0.04f;
            Destroy(this.gameObject);
            Debug.Log("can alindi.");

            /*if (Obstacle.killZombie == 1)
            {
                Obstacle.killZombie = 0;
                GameObject.Find("FillBar_In").GetComponent<Image>().fillAmount += 0.04f;
                Destroy(this.gameObject);
            }
       
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            GameObject.Find("FillBar_In").GetComponent<Image>().fillAmount += 0.055f;
            Destroy(this.gameObject);
            Debug.Log("can alindi.");
        }
    }

}
