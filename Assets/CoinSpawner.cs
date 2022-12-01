using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    public GameObject coins;
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;


    void Start()
    {
        if (PlayerPrefs.GetInt("car") == 1)
        {
            Player = car1;
        }
        if (PlayerPrefs.GetInt("car") == 2)
        {
            Player = car2;
        }
        if (PlayerPrefs.GetInt("car") == 3)
        {
            Player = car3;
        }
        if (PlayerPrefs.GetInt("car") == 4)
        {
            Player = car4;
        }
        if (PlayerPrefs.GetInt("car") == 5)
        {
            Player = car5;
        }
        if (PlayerPrefs.GetInt("car") == 6)
        {
            Player = car6;
        }
        if (PlayerPrefs.GetInt("car") == 7)
        {
            Player = car7;
        }
        if (PlayerPrefs.GetInt("car") == 8)
        {
            Player = car8;
        }
    }
    void Update()
    {
        if (Player != null)
        {
            float distanceToHorizon = Vector3.Distance(Player.gameObject.transform.position, spawnObstaclePosition);
            if (distanceToHorizon < 125)
            {
                SpawnTriangles();
            }
        }
    }
    void SpawnTriangles()
    {
        trianglePrefabs = ObjectPool2.SharedInstance.objectToPool;
        spawnObstaclePosition = new Vector3(Random.Range(-5, 5), 1f, spawnObstaclePosition.z + Random.Range(5, 30));
        trianglePrefabs[9] = ObjectPool2.SharedInstance.GetPooledObject();
        if (trianglePrefabs != null)
        {
            //spawnObstaclePosition = new Vector3(Random.Range(-5, 5), 1f, spawnObstaclePosition.z + Random.Range(1, 30));
            trianglePrefabs[9].transform.position = spawnObstaclePosition;
            trianglePrefabs[9].transform.rotation = Quaternion.identity;
            trianglePrefabs[9].transform.parent = coins.transform;
            trianglePrefabs[9].SetActive(true);
            
        }
        //Instantiate(trianglePrefabs[(Random.Range(0, trianglePrefabs.Length))], spawnObstaclePosition, Quaternion.identity, coins.transform);
    }
}
