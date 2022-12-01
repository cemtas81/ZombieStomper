using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MachineGun_Script : MonoBehaviour
{
    public Joystick joystick;
    Quaternion targetRotation;

    public float rotatespeed = 10f;
    private float _startingPosition;

    void Start()
    {
        DOTween.Init();
        //joystick = FindObjectOfType<Joystick>();
    }

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("MouseX") * 20f * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("MouseY") * 20f * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.forward, rotY);
    }

    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        if (joystick.Horizontal > 0)
        {
            if (Mathf.RoundToInt(transform.eulerAngles.y) < 5 || Mathf.RoundToInt(transform.eulerAngles.y - 360) >= -6)
                transform.eulerAngles += new Vector3(0, .1f, 0);

            Debug.Log(Mathf.RoundToInt(transform.eulerAngles.y));

        }

        else if (joystick.Horizontal < 0)
        {

            if (Mathf.RoundToInt(transform.eulerAngles.y) < 6 || Mathf.RoundToInt(transform.eulerAngles.y - 360) >= -5)
                transform.eulerAngles -= new Vector3(0, .1f, 0);

            Debug.Log(Mathf.RoundToInt(transform.eulerAngles.y));
        }

        else if (joystick.Vertical > 0)
        {
            if (Mathf.RoundToInt(transform.eulerAngles.x) > -5)
                transform.eulerAngles -= new Vector3(.1f, 0, 0);

            Debug.Log("yukari");
        }

        else if (joystick.Vertical < 0)
        {
            if (Mathf.RoundToInt(transform.eulerAngles.x) < 0)
                transform.eulerAngles += new Vector3(.1f, 0, 0);

            Debug.Log("asagi");

        }

        /*else if (joystick.Horizontal < 0)
        {
            rigidbody.velocity = new Vector3(joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f,
                        rigidbody.velocity.y,
                        -(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f));
            targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500f);
            //targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500f);
            
            
        }
        else if (joystick.Vertical > 0)
        {
            rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f,
                        rigidbody.velocity.y,
                        joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f);
            targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500f);
            //karakter.GetComponent<Rigidbody>().AddForce(transform.right * joystick.Vertical * 500);
            //karakter.GetComponent<Rigidbody>().rotation = karakter.GetComponent<Rigidbody>().rotation * Quaternion.AngleAxis(joystick.Horizontal*500, Vector3.forward);
            
        }
        else if (joystick.Vertical < 0)
        {
            rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f,
                        rigidbody.velocity.y,
                        joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f);
            targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500f);
            //targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500f);
           
        }*/
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}