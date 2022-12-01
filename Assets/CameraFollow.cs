using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject air;
    public Transform player;
    public Vector3 offset;
    public CarController on;
    public int tapcount;
    // Start is called before the first frame update
    void Start()
    {
        on=air. GetComponent<CarController>();
       
    }
   

    void LateUpdate()
    {
        
        if (on.onair==false)
        {
            transform.position = new Vector3(offset.x, offset.y, player.position.z - offset.z);
        }
        if (on.onair == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(offset.x, player.position.y + 4, player.position.z - 8), 4f*Time.deltaTime);
        }
        tapcount = on.tapcounter;

    }
    


}
