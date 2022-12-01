using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    public GameObject zombie;
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
            if (distanceToHorizon < 190)
            {
                SpawnTriangles();
                
            }
         
        }
       
    }
    void SpawnTriangles()
    {
        trianglePrefabs = ObjectPool.SharedInstance.objectToPool;
        spawnObstaclePosition = new Vector3(Random.Range(-5, 5), 0.1f, spawnObstaclePosition.z + Random.Range(0, 8));
        
        trianglePrefabs[14] = ObjectPool.SharedInstance.GetPooledObject();
        if (trianglePrefabs != null)
        {
            trianglePrefabs[14].transform.position = spawnObstaclePosition;
            trianglePrefabs[14].transform.rotation = Quaternion.Euler(0, 180, 0);
            trianglePrefabs[14].transform.parent = zombie.transform;
            trianglePrefabs[14].SetActive(true);
            
        }
    }
}
