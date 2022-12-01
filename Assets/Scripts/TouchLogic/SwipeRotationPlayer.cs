using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeRotationPlayer : TouchLogicV2//NOTE: This script has been updated to V2 after video recording
{
    public float rotateSpeed = 100.0f;
    public int invertPitch = 1;
    public Transform player;
    private float pitch = 0.0f,
    yaw = 0.0f;
    //cache initial rotation of player so pitch and yaw don't reset to 0 before rotating
    private Vector3 oRotation;

    [Header("Bullet Create")]
    public GameObject Bullet;
    public GameObject Bullet_leftPos;
    public GameObject Bullet_rightPos;
    public GameObject Bullet_Effect;
    public GameObject Right_Gun;
    public GameObject Left_Gun;
    float bullet_Timer;

    void Start()
    {
        //cache original rotation of player so pitch and yaw don't reset to 0 before rotating
        oRotation = player.eulerAngles;
        pitch = oRotation.x;
        yaw = oRotation.y;
    }

    public override void OnTouchBegan()
    {
        //need to cache the touch index that started on the pad so others wont interfere
        touch2Watch = TouchLogicV2.currTouch;
    }
    public override void OnTouchMoved()
    {
        pitch -= Input.GetTouch(touch2Watch).deltaPosition.y * rotateSpeed * invertPitch * Time.deltaTime;
        yaw += Input.GetTouch(touch2Watch).deltaPosition.x * rotateSpeed * invertPitch * Time.deltaTime;
        //limit so we dont do backflips
        pitch = Mathf.Clamp(pitch, -40, 0);
        yaw = Mathf.Clamp(yaw, -5, 5);

        //do the rotations of our camera
        player.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

    public override void OnTouchEnded()
    {
        bullet_Timer = 0;
        base.OnTouchEnded();
    }

    public override void OnTouchEndedAnywhere()
    {
        //the || condition is a failsafe
        if (TouchLogicV2.currTouch == touch2Watch || Input.touches.Length <= 0)
            touch2Watch = 64;
    }

    public void Bullet_Creation()
    {
        if (Zombie_Script.timer >= .15f)
        {
            Zombie_Script.timer = 0;
            Left_Gun.GetComponent<Animator>().SetTrigger("Finish");
            Right_Gun.GetComponent<Animator>().SetTrigger("Start");
            GameObject bulletLeft = Instantiate(Bullet);
            GameObject bulletEfect_Left = Instantiate(Bullet_Effect);
            bulletEfect_Left.transform.position = Bullet_leftPos.transform.position;
            bulletLeft.transform.position = Bullet_leftPos.transform.position;
            bulletLeft.GetComponent<Rigidbody>().velocity = new Vector3(yaw, -pitch, 70);
            Destroy(bulletLeft, 15f);
        }

        else
        {
            Left_Gun.GetComponent<Animator>().SetTrigger("Start");
            Right_Gun.GetComponent<Animator>().SetTrigger("Finish");
            GameObject bulletEfect_Right = Instantiate(Bullet_Effect);
            GameObject bulletRight = Instantiate(Bullet);
            bulletEfect_Right.transform.position = Bullet_rightPos.transform.position;
            bulletRight.transform.position = Bullet_rightPos.transform.position;
            bulletRight.GetComponent<Rigidbody>().velocity = new Vector3(yaw, -pitch, 70);
            Destroy(bulletRight, 15f);
        }
    }
}