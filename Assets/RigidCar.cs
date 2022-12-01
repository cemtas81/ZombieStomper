using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCar : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed;
    public GameObject sol;
    public GameObject sağ;
    public VariableJoystick joy;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
       // Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
       // pos.x = Mathf.Clamp01(pos.x);
       //rigid. transform.position = Camera.main.ViewportToWorldPoint(pos);
        rigid.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 4.0f * Time.deltaTime);
        //Vector3 pos = rigid.transform.position;
        //pos.x = Mathf.Clamp(rigid.transform.position.x , -3.2f, 3.2f);

        if (joy.Horizontal != 0)
        {
            rigid.AddRelativeForce(Vector3.forward * speed/2 * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigid.AddRelativeForce(Vector3.right * joy.Horizontal * 15 * Time.deltaTime, ForceMode.VelocityChange);
            //transform.RotateAround(Vector3.up, joy.Horizontal * Time.deltaTime * 1f);
            rigid.angularVelocity = joy.Horizontal * Vector3.right*Time.deltaTime*speed;
            sol.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, joy.Horizontal * 25, 0f), 10.0f * Time.deltaTime);
            sağ.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, joy.Horizontal * 25, 0f), 10.0f * Time.deltaTime);
        }
        else
        {
            rigid.AddRelativeForce(Vector3.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigid.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 5.0f * Time.deltaTime);
        }

    }
   

}
