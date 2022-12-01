using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    cubecontroller cubecontroller;
    public GameObject bloodEffect;
    public GameObject health_obj;
    public static int killZombie = 0;
    public GameObject greenBlood;
    public GameObject blood_pos;

    void Start()
    {
        killZombie = 0;
        cubecontroller = GameObject.FindObjectOfType<cubecontroller>();
    }

    private void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).gameObject.tag == "HealthBar") 
            {
                if (this.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount <= 0f) // zombielerin oldugunu kontrol eder.
                {
                    killZombie++;
                    GameObject blood = Instantiate(bloodEffect); // zombieler olunce kan efekti olusturur.
                    blood.transform.position = this.gameObject.transform.position;

                    GameObject health_prefab = Instantiate(health_obj); // zombieler olunce can olusturur.
                    health_prefab.transform.position = new Vector3(this.gameObject.transform.position.x,
                                                                    this.gameObject.transform.position.y + .8f,
                                                                    this.gameObject.transform.position.z);

                    health_prefab.transform.SetParent(this.transform.parent.gameObject.transform);

                    Destroy(blood, 1.5f);
                    //Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube") //tuzaklara Cube degerse oyun biter.
        {
            cubecontroller.Die();
            cubecontroller.FinishGame();
            Destroy(this.gameObject);
            //Kill the Player.

        }
       

        if(collision.gameObject.tag == "Bullet") //tuzaklara mermi degerse yok olur ve particle olusturur.
        {
            Destroy(collision.gameObject);
            GameObject green_Blood_effect = Instantiate(greenBlood); // mermiler zombielere degdikce kan efekti olusturur.
            green_Blood_effect.transform.position = collision.gameObject.transform.position;
            Destroy(green_Blood_effect, 1f);


            if (PlayerPrefs.GetInt("weaponLevel") <= PlayerPrefs.GetInt("level")) // silah seviyesi oyun seviyesine esitse ve dusukse 4 defada oldurur.
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    if (this.transform.GetChild(i).gameObject.tag == "HealthBar")
                    {
                        this.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount -= .25f;
                    }
                }
            }
            else if (PlayerPrefs.GetInt("weaponLevel") - PlayerPrefs.GetInt("level") == 1)// silah seviyesi oyun seviyesinden 1 buyukse 3 defada oldurur.
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    if (this.transform.GetChild(i).gameObject.tag == "HealthBar")
                    {
                        this.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount -= .34f;
                    }
                }
            }
            else if (PlayerPrefs.GetInt("weaponLevel") - PlayerPrefs.GetInt("level") == 2)// silah seviyesi oyun seviyesinden 2 buyukse 2 defada oldurur.
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    if (this.transform.GetChild(i).gameObject.tag == "HealthBar")
                    {
                        this.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount -= .5f;
                    }
                }
            }
            else if (PlayerPrefs.GetInt("weaponLevel") - PlayerPrefs.GetInt("level") >= 3)// silah seviyesi oyun seviyesinden 3 buyukse tek seferde oldurur.
            {
                killZombie++;
                GameObject blood = Instantiate(bloodEffect);
                blood.transform.position = this.gameObject.transform.position;

                GameObject health_prefab = Instantiate(health_obj);
                health_prefab.transform.position = new Vector3(this.gameObject.transform.position.x,
                                                                    this.gameObject.transform.position.y+.5f,
                                                                    this.gameObject.transform.position.z);

                health_prefab.transform.SetParent(this.transform.parent.gameObject.transform);

                Destroy(blood, 1.5f);
                Destroy(this.gameObject);
            }

        }
    }
}
