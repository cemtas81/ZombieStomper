using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;
public class UpgradeCar : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    //public GameObject[] cars;
    private Transform cam;
    private Camera cm;
    public GameObject car;
    private Transform cam2;
    public MeshRenderer armour1;
    public MeshRenderer armour2;
    public MeshRenderer armour3;
    public MeshRenderer armour4;
    public MeshRenderer armour5;
    public MeshRenderer armour6;
    public MeshRenderer armour7;
    public MeshRenderer armour8;
    public MeshRenderer armour9;
    public MeshRenderer armour10;
    public MeshRenderer armour11;
    public MeshRenderer armour12;
    public MeshRenderer armour13;
    public MeshRenderer armour14;
    public MeshRenderer armour15;
    public MeshRenderer armour16;
    public MeshRenderer armour17;
    public MeshRenderer armour18;
    public MeshRenderer armour19;
    public MeshRenderer armour20;
    public MeshRenderer armour21;
    public MeshRenderer armour22;
    public MeshRenderer armour23;
    public MeshRenderer armour24;
    private Button armupgrade;
    public Button engupgrade;
    public GameObject armup;
    public GameObject armup2;
    public GameObject armup3;
    private Button armupgrade2;
    private Button armupgrade3;
    public Button back;
    public Button sound;
    public Button vibrate;
    public Button quit;
    public Text coin;
    public float collectedcoin;
    public GameObject options;
    private bool pause;
    public GameObject p;
    public GameObject v;
     void Start()
   
    {
        Time.timeScale = 1;
       
        if (PlayerPrefs.GetInt("car1") == 1 && PlayerPrefs.GetInt("car") == 1)
        {
            car1.SetActive(true);

            car = car1;

        }
        if (PlayerPrefs.GetInt("car2") == 1 && PlayerPrefs.GetInt("car") == 2)
        {
            car2.SetActive(true);

            car = car2;
        }
        if (PlayerPrefs.GetInt("car3") == 1 && PlayerPrefs.GetInt("car") == 3)
        {
            car3.SetActive(true);

            car = car3;
        }
        if (PlayerPrefs.GetInt("car4") == 1 && PlayerPrefs.GetInt("car") == 4)
        {
            car4.SetActive(true);

            car = car4;
        }
        if (PlayerPrefs.GetInt("car5") == 1 && PlayerPrefs.GetInt("car") == 5)
        {
            car5.SetActive(true);

            car = car5;
        }
        if (PlayerPrefs.GetInt("car6") == 1 && PlayerPrefs.GetInt("car") == 6)
        {
            car6.SetActive(true);

            car = car6;
        }
        if (PlayerPrefs.GetInt("car7") == 1 && PlayerPrefs.GetInt("car") == 7)
        {
            car7.SetActive(true);

            car = car7;
        }
        if (PlayerPrefs.GetInt("car8") == 1 && PlayerPrefs.GetInt("car") == 8)
        {
            car8.SetActive(true);

            car = car8;
        }



        
        armupgrade = armup.GetComponent<Button>();
        armupgrade2 = armup2.GetComponent<Button>();
        armupgrade3 = armup3.GetComponent<Button>();
        cam = car.transform;
        cam2 = Camera.main.transform;
        armupgrade.onClick.AddListener(TaskOnClick);
        armupgrade2.onClick.AddListener(TaskOnClick2);
        armupgrade3.onClick.AddListener(TaskOnClick3);
        back.onClick.AddListener(TaskOnClick4);
        collectedcoin = PlayerPrefs.GetFloat("collected");
        coin.text = collectedcoin.ToString();
        sound.onClick.AddListener(Sound);
        vibrate.onClick.AddListener(Vib);
        quit.onClick.AddListener(Quit);
        
    }
    void Sound()
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
    void Vib()
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
    void Quit()
    {
        SceneManager.LoadScene(0);
    }
    void TaskOnClick()
    {
        if (car ==car1 ) 
        {
            if (armour1.enabled == false && collectedcoin >= 5000)
            {
                armour1.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm1", 1);
            }
          
           
        }
        if (car == car2) 
        {
            if (armour4.enabled == false && collectedcoin >= 5000)
            {
                armour4.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm2", 1);
            }
           

        }
        if (car == car3) 
        {
            if (armour7.enabled == false && collectedcoin >= 5000)
            {
                armour7.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm3", 1);
            }
           

        }
        if (car == car4) 
        {
            if (armour10.enabled == false && collectedcoin >= 5000)
            {
                armour10.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm4", 1);
            }
           

        }
        if (car == car5) 
        {
            if (armour13.enabled == false && collectedcoin >= 5000)
            {
                armour13.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm5", 1);
            }
           

        }
        if (car == car6) 
        {
            if (armour16.enabled == false && collectedcoin >= 5000)
            {
                armour16.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm6", 1);
            }
            

        }
        if (car == car7) 
        {
            if (armour19.enabled == false && collectedcoin >= 5000)
            {
                armour19.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm7", 1);
            }
           

        }
        if (car == car8)
        {
            if (armour22.enabled == false && collectedcoin >= 5000) 
            {
                armour22.enabled = true;
                armup2.SetActive(true);
                armup.SetActive(false);
                collectedcoin -= 5000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm8", 1);
            }
           

        }
    }
    void TaskOnClick2()
    {
        if (car == car1) 
        {
            if (armour1.enabled == true && collectedcoin >= 10000)
            {
                armour2.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm1", 2);
            }
           

        }
        if (car == car2)
        {
            if  (armour4.enabled == true && collectedcoin >= 10000)
            {
                armour5.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm2", 2);
            }
            

        }
        if (car == car3)
        {
            if  (armour7.enabled == true && collectedcoin >= 10000)
            {
                armour8.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm3", 2);
            }
           

        }
        if (car == car4)
        {
            if  (armour10.enabled == true && collectedcoin >= 10000)
            {
                armour11.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm4", 2);
            }
         

        }
        if (car == car5)
        {
            if  (armour13.enabled == true && collectedcoin >= 10000)
            {
                armour14.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm5", 2);
            }
            

        }
        if (car == car6)
        {
            if (armour16.enabled == true && collectedcoin >= 10000)
            {
                armour17.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm6", 2);
            }
            

        }
        if (car == car7)
        {
            if  (armour19.enabled == true && collectedcoin >= 10000)
            {
                armour20.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm7", 2);
            }
            

        }
        if (car == car8)
        {
            if  (armour22.enabled == true && collectedcoin >= 10000)
            {
                armour23.enabled = true;
                armup3.SetActive(true);
                armup2.SetActive(false);
                collectedcoin -= 10000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm8", 2);
            }
            

        }
    }
    void TaskOnClick3()
    {
        if (car == car1)
        {
            if  (armour2.enabled == true && collectedcoin >= 15000)
            {
                armour3.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm1", 3);
            }
            

        }
        if (car == car2) 
        {
            if (armour5.enabled == true && collectedcoin >= 15000)
            {
                armour6.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm2", 3);
            }
           

        }
        if (car == car3)
        {
            if  (armour8.enabled == true && collectedcoin >= 15000)
            {
                armour7.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm3", 3);
            }
          

        }
        if (car == car4)
            if  (armour11.enabled == true && collectedcoin >= 15000)
        {
            {
                armour12.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm4", 3);
            }
           
        }
        if (car == car5) 
        {
            if (armour14.enabled == true && collectedcoin >= 15000)
            {
                armour15.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm5", 3);
            }
           
        }
        if (car == car6)
        {
            if (armour17.enabled == true && collectedcoin >= 15000)
            {
                armour18.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm6", 3);
            }
            
        }
        if (car == car7)
        {
            if  (armour20.enabled == true && collectedcoin >= 15000)
            {
                armour21.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm7", 3);
            }
           
        }
        if (car == car8) 
        {
            if (armour23.enabled == true && collectedcoin >= 15000)
            {
                armour24.enabled = true;
                armup3.SetActive(false);
                collectedcoin -= 15000;
                coin.text = collectedcoin.ToString();
                PlayerPrefs.SetFloat("collected", collectedcoin);
                PlayerPrefs.SetInt("arm8", 3);
            }
            
        }

    }
        void TaskOnClick4()
    {
        if (pause == false)
        {
            options.SetActive(true);
            pause = true;
         
        }
        else
        {
            options.SetActive(false);
            pause = false;
          
        }
       
    }



    void Update()
    {



        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
           

            
            if (touch.phase == TouchPhase.Moved)
            {
               
                cam.Rotate(Vector3.up, touch.deltaPosition.x*Time.deltaTime*-3f);
                
                
                
            }


        }
        Time.timeScale = 1;



        if (PlayerPrefs.GetInt("car1") == 1 && PlayerPrefs.GetInt("car") == 1)
        {
            car1.SetActive(true);

            car = car1;
            if (PlayerPrefs.GetInt("arm1") == 1)
            {
                armour1.enabled = true;
                armour2.enabled = false;
                armour3.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm1") == 2)
            {
                armour1.enabled = true;
                armour2.enabled = true;
                armour3.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm1") == 3)
            {
                armour1.enabled = true;
                armour2.enabled = true;
                armour3.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car2") == 1 && PlayerPrefs.GetInt("car") == 2)
        {
            car2.SetActive(true);

            car = car2;
            if (PlayerPrefs.GetInt("arm2") == 1)
            {
                armour4.enabled = true;
                armour5.enabled = false;
                armour6.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm2") == 2)
            {
                armour4.enabled = true;
                armour5.enabled = true;
                armour6.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm2") == 3)
            {
                armour4.enabled = true;
                armour5.enabled = true;
                armour6.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car3") == 1 && PlayerPrefs.GetInt("car") == 3)
        {
            car3.SetActive(true);

            car = car3;
            if (PlayerPrefs.GetInt("arm3") == 1)
            {
                armour7.enabled = true;
                armour8.enabled = false;
                armour9.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm3") == 2)
            {
                armour7.enabled = true;
                armour8.enabled = true;
                armour9.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm3") == 3)
            {
                armour7.enabled = true;
                armour8.enabled = true;
                armour9.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car4") == 1 && PlayerPrefs.GetInt("car") == 4)
        {
            car4.SetActive(true);

            car = car4;
            if (PlayerPrefs.GetInt("arm4") == 1)
            {
                armour10.enabled = true;
                armour11.enabled = false;
                armour12.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm4") == 2)
            {
                armour10.enabled = true;
                armour11.enabled = true;
                armour12.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm4") == 3)
            {
                armour10.enabled = true;
                armour11.enabled = true;
                armour12.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car5") == 1 && PlayerPrefs.GetInt("car") == 5)
        {
            car5.SetActive(true);

            car = car5;
            if (PlayerPrefs.GetInt("arm5") == 1)
            {
                armour13.enabled = true;
                armour14.enabled = false;
                armour15.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm5") == 2)
            {
                armour13.enabled = true;
                armour14.enabled = true;
                armour15.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm5") == 3)
            {
                armour13.enabled = true;
                armour14.enabled = true;
                armour15.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car6") == 1 && PlayerPrefs.GetInt("car") == 6)
        {
            car6.SetActive(true);

            car = car6;
            if (PlayerPrefs.GetInt("arm6") == 1)
            {
                armour16.enabled = true;
                armour17.enabled = false;
                armour18.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm6") == 2)
            {
                armour16.enabled = true;
                armour17.enabled = true;
                armour18.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm6") == 3)
            {
                armour16.enabled = true;
                armour17.enabled = true;
                armour18.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car7") == 1 && PlayerPrefs.GetInt("car") == 7)
        {
            car7.SetActive(true);

            car = car7;
            if (PlayerPrefs.GetInt("arm7") == 1)
            {
                armour19.enabled = true;
                armour20.enabled = false;
                armour21.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm7") == 2)
            {
                armour19.enabled = true;
                armour20.enabled = true;
                armour21.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm7") == 3)
            {
                armour19.enabled = true;
                armour20.enabled = true;
                armour21.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("car8") == 1 && PlayerPrefs.GetInt("car") == 8)
        {
            car8.SetActive(true);

            car = car8;
            if (PlayerPrefs.GetInt("arm8") == 1)
            {
                armour22.enabled = true;
                armour23.enabled = false;
                armour24.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("arm8") == 2)
            {
                armour22.enabled = true;
                armour23.enabled = true;
                armour24.enabled = false;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(true);
            }
            if (PlayerPrefs.GetInt("arm8") == 3)
            {
                armour22.enabled = true;
                armour23.enabled = true;
                armour24.enabled = true;
                armup.SetActive(false);
                armup2.SetActive(false);
                armup3.SetActive(false);
            }
        }
    
    }
}
