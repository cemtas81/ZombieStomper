using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin_Magnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            
            other.gameObject.transform.DOMove(this.gameObject.transform.parent.transform.position, .25f);
        }
    }
}
