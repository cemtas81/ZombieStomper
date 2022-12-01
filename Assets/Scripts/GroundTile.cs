using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    public GameObject obstaclePrefab;

    public GameObject[] obstaclePrefab_Truck;

    public GameObject coinPrefab;

    List<int> obstacleList = new List<int> { 2, 3, 4 };

    public Vector3[] trapPositions;

    int Cube_Enter = 0;

    public static int zombiePrefab = 1;
    public static int tileExit = 5;
    public static int zombieDead = 0;

    public static int obstacleRandom_Truck = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cube_Enter = 0;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void Update()
    {
        //if (Cube_Enter == 1 && tileExit > 2)
        //{
        //    if (AdMob_Reward.gold_magnet == 1)
        //    {
        //        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        //        {
        //            if (this.gameObject.transform.GetChild(i).gameObject.tag == "coin")
        //            {
        //                this.gameObject.transform.GetChild(i).gameObject.transform.DOMove(new Vector3(GameObject.Find("Cube").transform.position.x, GameObject.Find("Cube").transform.position.y + 1.5f, GameObject.Find("Cube").transform.position.z), .2f);
        //            }
        //        }
        //    }

        //    if (AdMob_Reward.health_magnet == 1)
        //    {
        //        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        //        {
        //            if (this.gameObject.transform.GetChild(i).gameObject.tag == "Health_Obj")
        //            {
        //                this.gameObject.transform.GetChild(i).gameObject.transform.DOMove(new Vector3(GameObject.Find("Cube").transform.position.x, GameObject.Find("Cube").transform.position.y + 1.5f, GameObject.Find("Cube").transform.position.z), .2f);
        //            }
        //        }
        //    }
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
            Cube_Enter = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        //groundSpawner.SpawnTile(true);
        if (tileExit >= 6) //karakter 6. zemini gectikten sonra gerideki zombieleri yok eder.
        {
            for (int m = 0; m < GameObject.Find("GroundTileOBJ").transform.GetChild(zombieDead).childCount; m++)
            {
                if (GameObject.Find("GroundTileOBJ").transform.GetChild(zombieDead).transform.GetChild(m).gameObject.tag == "Zombie")
                {
                    Destroy(GameObject.Find("GroundTileOBJ").transform.GetChild(zombieDead).transform.GetChild(m).gameObject);
                }
            }
            if(zombieDead <29) //30 tane zemin oldugundan 29dan sonra artmiyor.
                zombieDead++;
            Debug.Log(zombieDead);
        }

        if (tileExit <= 29)//karakter zemini gectikten sonra ilerdeki zombileri active eder.
        {

            for (int i = 0; i < GameObject.Find("GroundTileOBJ").transform.GetChild(tileExit).childCount; i++)
            {
                if (GameObject.Find("GroundTileOBJ").transform.GetChild(tileExit).transform.GetChild(i).gameObject.tag == "Zombie")
                {
                    GameObject.Find("GroundTileOBJ").transform.GetChild(tileExit).transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            tileExit += 2;
        }

        //Debug.Log(tileExit);
        //Destroy(gameObject, 2);

    }

    public void SpawnObstacle()//zombie tuzaklarinin olusturulması.
    {
        if (zombiePrefab == 38)//zombie child i 38den sonra basa döner.
            zombiePrefab = 1;

        int obstacleRandom = Random.Range(1, 3);
        if (obstacleRandom == 1)
        {
            int obstacleSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            GameObject obs = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.Euler(0, 180, 0), transform);
            obs.transform.GetChild(zombiePrefab).gameObject.SetActive(true);

            zombiePrefab++;


            if (obstacleSpawnIndex == 2)
            {
                int selectCoinSpawnPoint = Random.Range(7, 9);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(selectCoinSpawnPoint).transform.GetChild(i).transform.position;
                }
            }
            else if (obstacleSpawnIndex == 3)
            {
                List<int> obstacleRandomList = new List<int> { 6, 8 };
                int selectCoinSpawnPoint = Random.Range(0, 2);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(obstacleRandomList[selectCoinSpawnPoint]).transform.GetChild(i).transform.position;
                }

            }
            else if (obstacleSpawnIndex == 4)
            {
                int selectCoinSpawnPoint = Random.Range(6, 8);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(selectCoinSpawnPoint).transform.GetChild(i).transform.position;
                }
            }
        }
        else
        {
            obstacleList = new List<int> { 2, 3, 4 };
            int obstacleSpawnIndex = obstacleList[Random.Range(0, obstacleList.Count)];
            obstacleList.Remove(obstacleSpawnIndex);
            int obstacleSpawnIndex2 = obstacleList[Random.Range(0, obstacleList.Count)];
            obstacleList.Remove(obstacleSpawnIndex2);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
            Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2).transform;

            GameObject obs1 = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.Euler(0, 180, 0), transform);
            GameObject obs2 = Instantiate(obstaclePrefab, spawnPoint2.position, Quaternion.Euler(0, 180, 0), transform);

            obs1.transform.GetChild(zombiePrefab).gameObject.SetActive(true);
            zombiePrefab++;
            obs2.transform.GetChild(zombiePrefab).gameObject.SetActive(true);
            zombiePrefab++;

            if (obstacleList[0] == 2)
            {

                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(6).transform.GetChild(i).transform.position;
                }
            }
            else if (obstacleList[0] == 3)
            {
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(7).transform.GetChild(i).transform.position;
                }
            }
            else if (obstacleList[0] == 4)
            {
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(8).transform.GetChild(i).transform.position;
                }
            }
        }
    }

    public void SpawnObstacle_Truck()// arac tuzaklarinin olusturulmasi.
    {
        if (obstacleRandom_Truck == 1)
            obstacleRandom_Truck = 2;
        else
            obstacleRandom_Truck = 1;



        if (obstacleRandom_Truck == 1)
        {
            int obstacleSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            GameObject obs = Instantiate(obstaclePrefab_Truck[Random.Range(0,6)], spawnPoint.position, Quaternion.Euler(0, 180, 0), transform);
            //obs.transform.GetChild(zombiePrefab).gameObject.SetActive(true);
            //zombiePrefab++;


            if (obstacleSpawnIndex == 2)
            {
                int selectCoinSpawnPoint = Random.Range(7, 9);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(selectCoinSpawnPoint).transform.GetChild(i).transform.position;
                }
            }
            else if (obstacleSpawnIndex == 3)
            {
                List<int> obstacleRandomList = new List<int> { 6, 8 };
                int selectCoinSpawnPoint = Random.Range(0, 2);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(obstacleRandomList[selectCoinSpawnPoint]).transform.GetChild(i).transform.position;
                }

            }
            else if (obstacleSpawnIndex == 4)
            {
                int selectCoinSpawnPoint = Random.Range(6, 8);
                int selectCoinSpawnNumber = Random.Range(1, 4);
                for (int i = 0; i < selectCoinSpawnNumber; i++)
                {
                    GameObject temp = Instantiate(coinPrefab, transform);
                    temp.transform.rotation = Quaternion.Euler(0, 180, 0);
                    temp.transform.position = transform.GetChild(selectCoinSpawnPoint).transform.GetChild(i).transform.position;
                }
            }
        }
    }

    public void SpawnCoins()//altinların olusturulmasi.
    {
        int coinsToSpawn = 3;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

        Vector3 GetRandomPointInCollider(Collider collider)
        {
            Vector3 point = new Vector3(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );

            if (point != collider.ClosestPoint(point))
            {
                point = GetRandomPointInCollider(collider);
            }

            point.y = .6f;
            return point;
        }
    }
}