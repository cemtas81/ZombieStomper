using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;
public class CarSelect : MonoBehaviour
{

    public Button but1;
    public Button but2;
    public Button pause;
    private Transform cam;
    private Camera cm;
    public float collectedcoin;
    public Text coin;
    public Button quit;
    public TextMesh c2;
    public TextMesh c3;
    public TextMesh c4;
    public TextMesh c5;
    public TextMesh c6;
    public TextMesh c7;
    public TextMesh c8;
    public GameObject p;
    public GameObject pausemenu;
    public GameObject v;
    public Button vibrate;
    public Button sound;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.pause = false;
        }
        if (PlayerPrefs.GetInt("Vibrate") == 0)
        {
            MMVibrationManager.SetHapticsActive(true);
        }
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.pause = true;

        }
        if (PlayerPrefs.GetInt("Vibrate") == 1)
        {

            MMVibrationManager.SetHapticsActive(false);
        }
        cam = Camera.main.transform;
        cm = Camera.main;
        Time.timeScale = 1;
        quit.onClick.AddListener(Quit);
        but1.onClick.AddListener(TaskOnClick);
        pause.onClick.AddListener(Pause);
        vibrate.onClick.AddListener(Vib);
        sound.onClick.AddListener(Sound);
        collectedcoin = PlayerPrefs.GetFloat("collected");
        coin.text = collectedcoin.ToString();
        but2.onClick.AddListener(TaskOnClick2);
        if (PlayerPrefs.GetInt("owned1")==1)
        {
            c2.text = "OWNED";
            c2.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned2") == 1)
        {
            c3.text = "OWNED";
            c3.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned3") == 1)
        {
            c4.text = "OWNED";
            c4.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned4") == 1)
        {
            c5.text = "OWNED";
            c5.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned5") == 1)
        {
            c6.text = "OWNED";
            c6.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned6") == 1)
        {
            c7.text = "OWNED";
            c7.color = Color.green;
        }
        if (PlayerPrefs.GetInt("owned7") == 1)
        {
            c8.text = "OWNED";
            c8.color = Color.green;
        }
    }
    void TaskOnClick()
    {
        collectedcoin += 100000;
        coin.text = collectedcoin.ToString();
        PlayerPrefs.SetFloat("collected", collectedcoin);
    }
    void TaskOnClick2()
    {
        PlayerPrefs.DeleteAll();
        collectedcoin = 0;
        coin.text = collectedcoin.ToString();
        PlayerPrefs.SetFloat("collected", collectedcoin);
    }
    void Pause()
    {
        if (pausemenu.activeSelf == false)
        {
            pausemenu.SetActive(true);
         
        }
        else
        {
            pausemenu.SetActive(false);
           
        }
        
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
        Application.Quit();
    }


    void Update()
    {



        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            Vector3 pos = cam.transform.position;
            pos.x = Mathf.Clamp(pos.x, -10.4f, 14.4f);

            //cm.transform.position = pos;
            if (touch.phase == TouchPhase.Moved)
            {
                cam.position = new Vector3(pos.x - touch.deltaPosition.x/3  * Time.deltaTime, cam.position.y, cam.position.z);
            }
            if (touch.phase == TouchPhase.Began)
            {

                Ray raycast = cm.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("Player"))
                    {
                        PlayerPrefs.SetInt("car", 1);
                        PlayerPrefs.SetInt("car1", 1);
                        PlayerPrefs.Save();
                        SceneManager.LoadScene(1);
                      
                        PlayerPrefs.SetInt("owned", 1);
                        PlayerPrefs.SetInt("car2", 0);
                        PlayerPrefs.SetInt("car3", 0);
                        PlayerPrefs.SetInt("car4", 0);
                        PlayerPrefs.SetInt("car5", 0);
                        PlayerPrefs.SetInt("car6", 0);
                        PlayerPrefs.SetInt("car7", 0);
                        PlayerPrefs.SetInt("car8", 0);
                    }
                    if (raycastHit.collider.CompareTag("Bullet"))
                    {
                        if (collectedcoin >= 55000 && PlayerPrefs.GetInt("owned1") != 1)
                        {
                            PlayerPrefs.SetInt("car", 2);
                            PlayerPrefs.SetInt("car2", 1);
                            PlayerPrefs.SetInt("owned1", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 55000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            c2.text = "OWNED";
                            c2.color = Color.green;
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                        }
                        if (PlayerPrefs.GetInt("owned1") == 1)
                        {
                            PlayerPrefs.SetInt("car2", 1);
                            PlayerPrefs.SetInt("car", 2);
                            PlayerPrefs.SetInt("owned1", 1);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                        }

                    }

                    if (raycastHit.collider.CompareTag("arm2"))
                    {
                        if (collectedcoin >= 50000 && PlayerPrefs.GetInt("owned2") != 1)
                        {
                            PlayerPrefs.SetInt("car", 3);
                            PlayerPrefs.SetInt("car3", 1);
                            PlayerPrefs.SetInt("owned2", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 50000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            c3.text = "OWNED";
                            c3.color = Color.green;
                        }
                        if (PlayerPrefs.GetInt("owned2") == 1)
                        {
                            PlayerPrefs.SetInt("car3", 1);
                            PlayerPrefs.SetInt("car", 3);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            PlayerPrefs.SetInt("owned2", 1);
                        }

                    }
                    if (raycastHit.collider.CompareTag("legs"))
                    {
                        if (collectedcoin >= 70000 && PlayerPrefs.GetInt("owned3") != 1)
                        {
                            PlayerPrefs.SetInt("car", 4);
                            PlayerPrefs.SetInt("car4", 1);
                            PlayerPrefs.SetInt("owned3", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 70000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            c4.text = "OWNED";
                            c4.color = Color.green;
                        }
                        if (PlayerPrefs.GetInt("owned3") == 1)
                        {
                            PlayerPrefs.SetInt("car4", 1);
                            PlayerPrefs.SetInt("car", 4);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            PlayerPrefs.SetInt("owned3", 1);
                        }
                    }
                    if (raycastHit.collider.CompareTag("head"))
                    {
                        if (collectedcoin >= 75000 && PlayerPrefs.GetInt("owned4") != 1)
                        {
                            PlayerPrefs.SetInt("car", 5);
                            PlayerPrefs.SetInt("car5", 1);
                            PlayerPrefs.SetInt("owned4", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 75000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            c5.text = "OWNED";
                            c5.color = Color.green;
                        }
                        if (PlayerPrefs.GetInt("owned4") == 1)
                        {
                            PlayerPrefs.SetInt("car5", 1);
                            PlayerPrefs.SetInt("car", 5);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            PlayerPrefs.SetInt("owned4", 1);
                        }
                    }
                    if (raycastHit.collider.CompareTag("torso"))
                    {
                        if (collectedcoin >= 100000 && PlayerPrefs.GetInt("owned5") != 1)
                        {
                            PlayerPrefs.SetInt("car", 6);
                            PlayerPrefs.SetInt("car6", 1);
                            PlayerPrefs.SetInt("owned5", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 100000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            c6.text = "OWNED";
                            c6.color = Color.green;
                        }
                        if (PlayerPrefs.GetInt("owned5") == 1)
                        {
                            PlayerPrefs.SetInt("car6", 1);
                            PlayerPrefs.SetInt("car", 6);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            PlayerPrefs.SetInt("owned5", 1);
                        }
                    }
                    if (raycastHit.collider.CompareTag("gut"))
                    {
                        if (collectedcoin >= 200000 && PlayerPrefs.GetInt("owned6") != 1)
                        {
                            PlayerPrefs.SetInt("car", 7);
                            PlayerPrefs.SetInt("car7", 1);
                            PlayerPrefs.SetInt("owned6", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 200000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            c7.text = "OWNED";
                            c7.color = Color.green;

                        }
                        if (PlayerPrefs.GetInt("owned6") == 1)
                        {
                            PlayerPrefs.SetInt("car7", 1);
                            PlayerPrefs.SetInt("car", 7);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("car8", 0);
                            PlayerPrefs.SetInt("owned6", 1);
                        }

                    }
                    if (raycastHit.collider.CompareTag("arm1"))
                    {
                        if (collectedcoin >= 700000 && PlayerPrefs.GetInt("owned7") != 1)
                        {
                            PlayerPrefs.SetInt("car", 8);
                            PlayerPrefs.SetInt("car8", 1);
                            PlayerPrefs.SetInt("owned7", 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene(1);
                            collectedcoin -= 700000;
                            coin.text = collectedcoin.ToString();
                            PlayerPrefs.SetFloat("collected", collectedcoin);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            c8.text = "OWNED";
                            c8.color = Color.green;
                        }
                        if (PlayerPrefs.GetInt("owned7") == 1)
                        {
                            PlayerPrefs.SetInt("car8", 1);
                            PlayerPrefs.SetInt("car", 8);
                            SceneManager.LoadScene(1);
                            PlayerPrefs.SetInt("car2", 0);
                            PlayerPrefs.SetInt("car3", 0);
                            PlayerPrefs.SetInt("car4", 0);
                            PlayerPrefs.SetInt("car5", 0);
                            PlayerPrefs.SetInt("car6", 0);
                            PlayerPrefs.SetInt("car7", 0);
                            PlayerPrefs.SetInt("car1", 0);
                            PlayerPrefs.SetInt("owned7", 1);
                        }

                    }


                    



                }

            }
        }
    }
}