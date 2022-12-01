using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieNewCar : MonoBehaviour
{
    private CapsuleCollider col;
   
    public ParticleSystem blood;
    private AudioSource audio1;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        audio1 = GetComponentInParent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            
            col.enabled = false;
           
            blood.transform.position = this.gameObject.transform.position;
            
            blood.Play();
            audio1.Play();
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
