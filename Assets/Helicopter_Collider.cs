using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helicopter_Collider : MonoBehaviour
{
    public GameObject target;
    public GameObject helicopter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
            helicopter.transform.DOMove(target.transform.position, 10f).OnComplete(() => Destroy(helicopter));
    }
}
