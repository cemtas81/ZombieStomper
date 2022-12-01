using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        GameObject. Instantiate(level); 
    }

   
}
