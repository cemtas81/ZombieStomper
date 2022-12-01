using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Hit_Bus : MonoBehaviour
{
    public GameObject Zombie_Boss;
    public GameObject Bus;
    public GameObject target;

    public AudioSource hitSource;
    public AudioSource busSource;
    public AudioClip busSoundClip;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            Invoke("Invoke_Sound", .4f);
            Zombie_Boss.GetComponent<Animator>().SetTrigger("Turn");
            Bus.transform.DOMove(target.transform.position, 4f).OnComplete(() => Destroy(Bus));
            Invoke("SetParent", .4f);

        }
    }

    void Invoke_Sound()
    {
        hitSource.GetComponent<AudioSource>().Play();

    }

    void SetParent()
    {
        Zombie_Boss.transform.SetParent(Bus.transform);
    }
}
