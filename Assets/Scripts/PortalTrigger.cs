using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] Material[] cubeMaterials;
    public static int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material = cubeMaterials[i];
        GameObject.Find("Cube").transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        if(i<3)
            i++;
    }
}
