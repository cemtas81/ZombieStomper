using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBossDie : MonoBehaviour
{
    private Animator ani;
    public GameObject bloodEffect;

    private void Start()
    {
        ani = GetComponent <Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ani.SetTrigger("dead");
            GameObject blood = Instantiate(bloodEffect);
            blood.transform.position = new Vector3( this.gameObject.transform.position.x,this.gameObject.transform.position.y+10f,this.gameObject.transform.position.z);
            Destroy(blood, 1);
        }
        if (other.gameObject.CompareTag("MainCamera"))
        {
            Destroy(this.gameObject);
        }
    }

}

