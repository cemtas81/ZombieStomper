using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner_Truck : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject portalPrefab;

    public static float allCoinCount;
    public static float percent;

    public GameObject GroundTile_Parent;

    GameObject temp;

    Vector3 nextSpawnPoint;

    void Start()
    {
        Time.timeScale = 0;

        //Random.seed = PlayerPrefs.GetInt("level");

        allCoinCount = 0;
        percent = 0;
        for (int i = 0; i < 30; i++)
        {
            if (i < 1) //Ilk yolda tuzak olmamasi.
            {
                SpawnTile(false);//tuzaklar basılmıyor.
            }
            else
            {
                SpawnTile(true);//tuzaklar basılıyor.

                /*zombieFalse++;

                if (zombieFalse >= 5)//zemin olusturulduktan sonra 5.den itibaren zombiler kapatiliyor.
                {
                    for (int j = 0; j < GroundTile_Parent.transform.GetChild(zombieFalse).childCount; j++)
                    {
                        if (GroundTile_Parent.transform.GetChild(zombieFalse).transform.GetChild(j).gameObject.tag == "Zombie")
                        {
                            GroundTile_Parent.transform.GetChild(zombieFalse).transform.GetChild(j).gameObject.SetActive(false);
                        }
                    }
                }
                */
                if (i == 7)
                    SpawnPortal();
                else if (i == 14)
                    SpawnPortal();
                else if (i == 21)
                    SpawnPortal();
            }
        }
        AllCoinCount();
    }

   
    void Update()
    {
        
    }

    public void SpawnTile(bool spawnItems) //Yolun oluşuturulması.
    {
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity, GroundTile_Parent.transform);
        nextSpawnPoint = temp.transform.GetChild(1).position; //Yolun oluşturulacagi pozisyon.

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle_Truck(); //Tuzaklarin olusturulmasi.
            //temp.GetComponent<GroundTile>().SpawnCoins(); // Altinların olusturulmasi.
        }
    }

    public void SpawnPortal() //Portalların oluşturulması.
    {
        GameObject temp2 = Instantiate(portalPrefab);
        temp2.transform.position = temp.transform.GetChild(5).position;
    }

    public void AllCoinCount()//Olusturalan altinların yuzde hesabi.
    {
        allCoinCount = GameObject.FindGameObjectsWithTag("coin").Length;
        percent = 100 / allCoinCount;
        allCoinCount = 1 / allCoinCount;
    }

}
