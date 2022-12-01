using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    FillingBar fillingBar;

    public float turnSpeed = 90f;
    public static float collectedCoin;
    private AudioSource audio1;
    
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }*/

        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            collectedCoin++;
            audio1.Play();
        }
            

        
        //fillingBar.FillBar(GroundSpawner.allCoinCount,GroundSpawner.percent);
        //Destroy(gameObject);
       

    }

    void Start()
    {
        collectedCoin = 0;
        fillingBar = GameObject.FindObjectOfType<FillingBar>();
        audio1 = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime , 0);
        if (transform.position.z<Camera.main.transform.position.z)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Coin_Collected()
    {
        PlayerPrefs.SetInt("allCoin", (int)((PlayerPrefs.GetInt("allCoin")) + (collectedCoin*RangeBar.multiplier)));
    }
}
