using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("zombie boss here");
    }
}
