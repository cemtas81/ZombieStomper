using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;
using GoogleMobileAds.Api;
public class VehicleChange : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    public GameObject[] sky;
    public Button back;
    public GameObject car;
    public MeshRenderer arm1;
    public MeshRenderer arm2;
    public MeshRenderer arm3;
    public GameObject pausemenu;
    public bool pause;
    public Button upgrade;
    public Button sound;
    public Button vibrate;
    public Canvas canvas;
    
    public GameObject v;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.pause = true;
        }
        if (PlayerPrefs.GetInt("Vibrate") == 1)
        {
            MMVibrationManager.SetHapticsActive(false);
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.pause = false;

        }
        if (PlayerPrefs.GetInt("Vibrate") == 0)
        {

            MMVibrationManager.SetHapticsActive(true);
        }


        if (PlayerPrefs.GetInt("car") ==1)
        {

            car1.SetActive(true);
            car = car1;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm1")==1)
            {
                arm1.enabled = true;
                arm2.enabled = false;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm1") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm1") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm1") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }
            
        }
        if (PlayerPrefs.GetInt("car") == 2)
        {
            car2.SetActive(true);
            car = car2;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm2") == 1)
            {
                arm1.enabled = true;
                arm2.enabled = false;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm2") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm2") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm2") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 3)
        {
            car3.SetActive(true);
            car = car3;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm3") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm3") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm3") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm3") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 4)
        {
            car4.SetActive(true);
            car = car4;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm4") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm4") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm4") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm4") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 5)
        {
            car5.SetActive(true);
            car = car5;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm5") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm5") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm5") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm5") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 6)
        {
            car6.SetActive(true);
            car = car6;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm6") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm6") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm6") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm6") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 7)
        {
            car7.SetActive(true);
            car = car7;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm7") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm7") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm7") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm7") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
        if (PlayerPrefs.GetInt("car") == 8)
        {
            car8.SetActive(true);
            car = car8;
            canvas = car.GetComponentInChildren<Canvas>();
            arm1 = GameObject.FindGameObjectWithTag("arm1").GetComponent<MeshRenderer>();
            arm2 = GameObject.FindGameObjectWithTag("arm2").GetComponent<MeshRenderer>();
            arm3 = GameObject.FindGameObjectWithTag("arm3").GetComponent<MeshRenderer>();
            if (PlayerPrefs.GetInt("arm8") == 1)
            {
                arm1.enabled = true;
                arm3.enabled = false;
                arm2.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm8") == 2)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = false;
            }
            if (PlayerPrefs.GetInt("arm8") == 3)
            {
                arm1.enabled = true;
                arm2.enabled = true;
                arm3.enabled = true;
            }
            if (PlayerPrefs.GetInt("arm8") == 0)
            {
                arm1.enabled = false;
                arm2.enabled = false;
                arm3.enabled = false;
            }

        }
       
            


        if (PlayerPrefs.GetInt("next")==0)
        {
            sky[0].SetActive(true);
            sky[1].SetActive(false);
            sky[2].SetActive(false);
            sky[3].SetActive(false);
            sky[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("next") == 1)
        {
            sky[1].SetActive(true);
            sky[0].SetActive(false);
            sky[2].SetActive(false);
            sky[3].SetActive(false);
            sky[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("next") == 2)
        {
            sky[2].SetActive(true);
            sky[0].SetActive(false);
            sky[1].SetActive(false);
            sky[3].SetActive(false);
            sky[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("next") == 3)
        {
            sky[3].SetActive(true);
            sky[0].SetActive(false);
            sky[2].SetActive(false);
            sky[1].SetActive(false);
            sky[4].SetActive(false);
        }
        if(PlayerPrefs.GetInt("next")==4)
        {
            sky[4].SetActive(true);
            sky[0].SetActive(false);
            sky[2].SetActive(false);
            sky[3].SetActive(false);
            sky[1].SetActive(false);

        }

        back.onClick.AddListener(Task1);
        upgrade.onClick.AddListener(Task2);
        sound.onClick.AddListener(Task3);
        vibrate.onClick.AddListener(Task4);
    }
    void Task1()
    {
        if (pause==false)
        {
            pausemenu.SetActive(true);
            pause = true;
            Time.timeScale = 0;
            canvas.enabled = false;
     
        }
        else
        {
            pausemenu.SetActive(false);
            pause = false;
            Time.timeScale = 1;
            canvas.enabled = true;

        }

    }
    void Task2()
    {
        
        SceneManager.LoadScene(1);
        
    }
    void Task3()
    {
        AudioListener.pause = !AudioListener.pause;
        if (p.activeSelf==false)
        {
            p.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.Save();
        }
        else
        {
            p.SetActive(false);
            PlayerPrefs.SetInt("Sound", 0);
            PlayerPrefs.Save();
        }

    }
    void Task4()
    {
        if (v.activeSelf==true)
        {
            MMVibrationManager.SetHapticsActive(false);
            v.SetActive(false);
            PlayerPrefs.SetInt("Vibrate", 1);
            PlayerPrefs.Save();
        }
        else
        {
            MMVibrationManager.SetHapticsActive(true);
            v.SetActive(true);
            PlayerPrefs.SetInt("Vibrate", 0);
            PlayerPrefs.Save();
        }
    }

}
