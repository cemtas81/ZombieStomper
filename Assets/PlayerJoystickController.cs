using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
 
    void Update()
    {
        Vector3 lookVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 4096);
        Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
