using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeCar2 : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    public Button armup1;
    public Button armup2;
    public Button armup3;
    public MeshRenderer armour1;
    public MeshRenderer armour2;
    public MeshRenderer armour3;
    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
        armour1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
        armour2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
        armour3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
        armup1.onClick.AddListener(Up1);
        armup2.onClick.AddListener(Up2);
        armup3.onClick.AddListener(Up3);
        if (PlayerPrefs.GetInt("car")==1)
        {
            car1.SetActive(true);
            cam = car1.transform;
        }
        if (PlayerPrefs.GetInt("car")==2)
        {
            car2.SetActive(true);
            cam = car2.transform;
        }
        if (PlayerPrefs.GetInt("car") == 3)
        {
            car3.SetActive(true);
            cam = car3.transform;
        }
        if (PlayerPrefs.GetInt("car") == 4)
        {
            car4.SetActive(true);
            cam = car4.transform;
        
        }
        if (PlayerPrefs.GetInt("car") == 5)
        {
            car5.SetActive(true);
            cam = car5.transform;
         
        }
        if (PlayerPrefs.GetInt("car") == 6)
        {
            car6.SetActive(true);
            cam = car6.transform;
          
        }
        if (PlayerPrefs.GetInt("car") == 7)
        {
            car7.SetActive(true);
            cam = car7.transform;
        }
        if (PlayerPrefs.GetInt("car") == 8)
        {
            car8.SetActive(true);
            cam = car8.transform;
        }

    }
    void Up1()
    {

    }
    void Up2()
    {

    }
    void Up3()
    {

    }

    void Update()
    {



        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);



            if (touch.phase == TouchPhase.Moved)
            {

                cam.RotateAround(Vector3.up, touch.deltaPosition.x * Time.deltaTime * -0.1f);



            }


        }
    }
}
