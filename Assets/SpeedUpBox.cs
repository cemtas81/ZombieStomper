using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBox : MonoBehaviour
{
    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            col.enabled=false;
        }
    }
}
