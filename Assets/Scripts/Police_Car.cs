using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Police_Car : MonoBehaviour
{
    public GameObject Police_Cars;
    public GameObject Target;
    public AudioSource hitSoundSource;
    public AudioClip hitSoundClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            Invoke("Invoke_Sound",3.2f);
            Police_Cars.transform.DOMove(Target.transform.position, 4.5f).OnComplete(() => Destroy(Police_Cars));
        }
    }

    void Invoke_Sound()
    {
        //hitSoundSource.GetComponent<AudioSource>().volume = .2f;
        hitSoundSource.GetComponent<Animator>().SetTrigger("soundStart");
        hitSoundSource.PlayOneShot(hitSoundClip, 1);
    }
}
