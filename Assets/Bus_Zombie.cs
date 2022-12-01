using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus_Zombie : MonoBehaviour
{
    public GameObject Bus;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.name == "Crash_Bus")
        {
            Debug.Log("OTOBUS TEMASLANDI.");
            this.transform.SetParent(Bus.transform);
        }*/
    }
}
