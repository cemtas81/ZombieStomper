using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlow : MonoBehaviour
{
    
    public GameObject blowup;


    // Start is called before the first frame update
    void Start()
    {
       

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {

            if (PlayerPrefs.GetInt("car")==8)
            {
                GameObject blood = Instantiate(blowup);
                blood.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+1f, this.gameObject.transform.position.z);
                Destroy(blood, 1);
                this.gameObject.SetActive(false);
            }
            
        }
        if (collision.collider.gameObject.CompareTag("MainCamera"))
        {
            this.gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
