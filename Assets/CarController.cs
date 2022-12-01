using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;
using Cinemachine;
using TMPro;


public class CarController : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed;
    public VariableJoystick joy;
    public GameObject sol;
    public GameObject sağ;
    public GameObject solarka;
    public GameObject sağarka;
    public GameObject fire;
    public float speedorg;
    public GameObject blood;
    public float collectedcoin;
    public GameObject Age_Bar;
    public GameObject Karakter_Bar;
    public GameObject tapbar;
    public Text coin;
    public BoxCollider head;
    public BoxCollider torso;
    public BoxCollider gut;
    public BoxCollider legs;
    public GameObject restart;
    public GameObject nextlevel;
    public GameObject fincam;
    public int killZombie;
    public Text kill;
    public bool onair;
    public Button tap;
    public int tapcounter;
    public GameObject tapbutton;
    public Transform land;
    public GameObject zombies;
    public GameObject obstacles;
    public GameObject coins;
    public GameObject bonuses;
    public GameObject cam2;
    private CinemachineVirtualCamera cam;
    public CinemachineVirtualCamera camv;
    public GameObject canvas;
    public Button start;
    AudioSource audio;
    public GameObject scenemanager;
    public MeshRenderer arm1;
    public MeshRenderer arm2;
    public MeshRenderer arm3;
    public GameObject tap1;
    public GameObject tap2;
    public GameObject tap3;
    public GameObject tap4;
    public GameObject tap5;
    private CinemachineFramingTransposer camy;
    public TextMeshProUGUI finalkill;
    public float finalcoin;
    public Text coinfinal;
    public float bosscoin;
    public TextMeshProUGUI coinboss;
    public Button pause;
    public ParticleSystem bloody;
    public Button add;
    public Text addx3;
    public GameObject ad3;
    Reward reward;
    public int odul;
    private void Start()
    {
        cam = cam2.GetComponent<CinemachineVirtualCamera>();
        rigid = GetComponent<Rigidbody>();
        PlayerPrefs.GetFloat("collected");
        collectedcoin = PlayerPrefs.GetFloat("collected");
        coin.text = collectedcoin.ToString();
        PlayerPrefs.GetInt("killed");
        kill.text = killZombie.ToString();
        //Time.timeScale = 0f;
        onair = false;
        tap.onClick.AddListener(TaskOnClick);
        Age_Bar.GetComponent<Image>().fillAmount = 1f;
        tapbar.GetComponent<Image>().fillAmount = 0f;
        rigid.centerOfMass = new Vector3(0, -1, 0);
        cam.LookAt = this.transform;
        cam.Follow = this.transform;
        camv.LookAt = this.transform;
        camv.Follow = this.transform;
        canvas.SetActive(false);
        audio = GetComponent<AudioSource>();
        audio.PlayDelayed(0.2f);
        start.onClick.AddListener(TaskOnClick2);
        reward = GetComponent<Reward>();
        odul = reward.odulAlindi;

    }
    void TaskOnClick2()
    {
        canvas.SetActive(true);
    }
    void TaskOnClick()
    {
        tapcounter++;
    }
    void Update()
    {
        if ( Age_Bar.GetComponent<Image>().fillAmount > 0)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }

        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x , -4.4f, 4.4f);
        pos.y = Mathf.Clamp(pos.y, 0, 17);
       
        transform.position = pos;
        
        if (onair == false && Age_Bar.GetComponent<Image>().fillAmount > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, joy.Horizontal * speed / 1.8f, 0f), 200.0f * Time.deltaTime);
            sol.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(180, joy.Horizontal * 30, 0f), 5.0f * Time.deltaTime);
            sağ.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(180, joy.Horizontal * 30, 0f), 5.0f * Time.deltaTime);
            solarka.transform.Rotate(Vector3.right * 180 * Time.deltaTime);
            sağarka.transform.Rotate(Vector3.right * 180 * Time.deltaTime);
        }
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Moved|onair==false)
        //    {
        //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, touch.deltaPosition.x*speed*Time.smoothDeltaTime/5f, 0f), 0.9f * Time.deltaTime);
        //        sol.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, touch.deltaPosition.x * 2, 0f), 5.0f * Time.deltaTime);
        //        sağ.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, touch.deltaPosition.x * 2, 0f), 5.0f * Time.deltaTime);
        //    }
        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0f), 2.0f * Time.deltaTime);
        //        sol.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0f), 5.0f * Time.deltaTime);
        //        sağ.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0f), 5.0f * Time.deltaTime);
        //    }
        //}

        if (PlayerPrefs.GetInt("car") == 8 && speed <= 15)
        {
            Age_Bar.GetComponent<Image>().fillAmount = 0;
        }
        if (speed<=20&& PlayerPrefs.GetInt("car") != 8)
        {
            Age_Bar.GetComponent<Image>().fillAmount = 0;
        }

        if (Age_Bar.GetComponent<Image>().fillAmount <= 0)
        {
            speed = 0f;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            fire.SetActive(true);
            StartCoroutine(VibrateDuration());
            if (PlayerPrefs.GetInt("Vibrate")==0)
            {
                MMVibrationManager.Haptic(HapticTypes.RigidImpact);
            }
           
            canvas.SetActive(false);
            audio.Stop();
            solarka.transform.Rotate(Vector3.zero);
            sağarka.transform.Rotate(Vector3.zero);
            sol.transform.Rotate(Vector3.zero);
            sağ.transform.Rotate(Vector3.zero);
            
        }
        if (onair==true)
        {
            if (tapcounter == 1)
            {
                speed = 63f;
                cam.m_Lens.FieldOfView = 101;
                tapbar.GetComponent<Image>().fillAmount = 0.15f;

            }
            if (tapcounter == 2)
            {
                speed = 66f;
                cam.m_Lens.FieldOfView = 105;
                tapbar.GetComponent<Image>().fillAmount = 0.3f;
            }
            if (tapcounter == 3)
            {
                speed = 69f;
                cam.m_Lens.FieldOfView = 109;
                tapbar.GetComponent<Image>().fillAmount = 0.45f;
            }
            if (tapcounter == 4)
            {
                speed = 72f;
                cam.m_Lens.FieldOfView = 114;
                tapbar.GetComponent<Image>().fillAmount = 0.6f;
            }
            if (tapcounter == 5)
            {
                speed = 75f;
                cam.m_Lens.FieldOfView = 119;
                tapbar.GetComponent<Image>().fillAmount = 0.7f;
            }
            if (tapcounter == 6)
            {
                speed = 78f;
                cam.m_Lens.FieldOfView = 124;
                tapbar.GetComponent<Image>().fillAmount = 0.8f;
            }
            if (tapcounter >= 7)
            {
                speed = 81f;
                cam.m_Lens.FieldOfView = 129;
                tapbar.GetComponent<Image>().fillAmount = 0.9f;
            }
        }



    }
    public IEnumerator VibrateDuration()
    {
        yield return new WaitForSecondsRealtime(1f);
       
        restart.SetActive(true);
        MMVibrationManager.StopAllHaptics(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Zombie"))
        {
            if (arm1.enabled==true&&arm2.enabled==false&&arm3.enabled==false)
            {
                speed -= 0.2f;
                Age_Bar.GetComponent<Image>().fillAmount -= 0.008f;
            }
            if (arm2.enabled==true&&arm3.enabled==false)
            {
                speed -= 0.15f;
                Age_Bar.GetComponent<Image>().fillAmount -= 0.006f;
            }
            if (arm3.enabled==true)
            {
                speed -= 0.10f;
                Age_Bar.GetComponent<Image>().fillAmount -= 0.004f;
            }
            if(arm1.enabled==false)
            {
                speed -= 0.25f;
                Age_Bar.GetComponent<Image>().fillAmount -= 0.01f;
            }
            
            collision.collider.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("Vibrate") == 0)
            {
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
            }
            
            killZombie++;
            PlayerPrefs.SetInt("killed", killZombie);
            kill.text = killZombie.ToString();
        }
        
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            if (PlayerPrefs.GetInt("car")==8&& PlayerPrefs.GetInt("car8") == 1)
            {
                speed -= 5f;
                Age_Bar.GetComponent<Image>().fillAmount -= 0.35f;
            }
            if (PlayerPrefs.GetInt("car") != 8&& PlayerPrefs.GetInt("car8") != 1)
            {
                speed = 0f;
                
                rigid.isKinematic = true;
            }
           
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("torso"))
        {
            StartCoroutine(Land());
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(15f, 0f, 0f), 50.0f * Time.deltaTime);
         
            bosscoin += 500;
            head.enabled=false;
            gut.enabled = false;
            legs.enabled = false;
            torso.enabled = false;
        }
        if (other.gameObject.CompareTag("gut"))
        {
           
            bosscoin += 200;
            StartCoroutine(Land());
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(10f, 0f, 0f), 50.0f * Time.deltaTime);
            head.enabled = false;
            torso.enabled = false;
            legs.enabled = false;
            gut.enabled = false;
        }
        if (other.gameObject.CompareTag("legs"))
        {
       
            bosscoin += 100;
            StartCoroutine(Land());
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(5f, 0f, 0f), 5.0f * Time.deltaTime);
            head.enabled = false;
            gut.enabled = false;
            torso.enabled = false;
            legs.enabled = false;
        }
        if (other.gameObject.CompareTag("head"))
        {
          
            bosscoin += 1000;
            StartCoroutine(Land());
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(80f, 0f, 0f), 20.0f * Time.deltaTime);
            torso.enabled = false;
            gut.enabled = false;
            legs.enabled = false;
            head.enabled = false;
        }


        IEnumerator Land()
        {
            yield return new WaitForSecondsRealtime(1.2f);
            transform.position = land.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 15, 0f), 300.0f * Time.deltaTime);
            fincam.SetActive(true);
            onair = false;

        }
        if (other.gameObject.CompareTag("Health_Obj"))
        {
           
            if (PlayerPrefs.GetInt("Vibrate") == 0)
            {
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            }
            other.gameObject.SetActive(false);
            if (speed >= 31)
            {
                speed = speedorg;
                Age_Bar.GetComponent<Image>().fillAmount = 1f;
            }
            else
            {
                speed += 10f;
                Age_Bar.GetComponent<Image>().fillAmount += 0.25f;
            }
        }
        if (other.gameObject.CompareTag("coin"))
        {
            collectedcoin+=10;
            coin.text = collectedcoin.ToString();
           
        }
        if (other.gameObject.CompareTag("Finish"))
        {
           
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            sol.transform.Rotate(Vector3.zero);
            sağ.transform.Rotate(Vector3.zero);
            StartCoroutine(Finish());
            fincam.SetActive(true);
        }
        IEnumerator Finish()
        {
            yield return new WaitForSecondsRealtime(0.75f);
            Time.timeScale = 0;
            pause.enabled = false;
            nextlevel.SetActive(true);
            finalkill.text ="+"+ kill.text;
            finalcoin = killZombie +bosscoin+collectedcoin;
            coinfinal.text = finalcoin.ToString();
            coinboss.text = "+" + bosscoin.ToString();
            PlayerPrefs.SetFloat("collected", finalcoin);
            PlayerPrefs.Save();
            addx3.text ="+" +3000.ToString();
            add.onClick.AddListener(x3);
        }
        void x3()
        {
            
                finalcoin = killZombie + bosscoin + collectedcoin + 3000f;
                coinfinal.text = finalcoin.ToString();
                PlayerPrefs.SetFloat("collected", finalcoin);
                PlayerPrefs.Save();

                ad3.gameObject.SetActive(false);
            
            
        }
        if (other.gameObject.CompareTag("speedboost"))
        {
            canvas.SetActive(false);
           
            obstacles.SetActive(false);
            tapbutton.SetActive(true);
            StartCoroutine(Tapy());
            speed = 60f;
            onair = true;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            transform.position = new Vector3(0, 0, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0f), 200.0f * Time.deltaTime);
            sol.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0f), 50.0f * Time.deltaTime);
            sağ.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), 50f * Time.deltaTime);
            camy = camv.GetComponent<CinemachineFramingTransposer>();
            if (PlayerPrefs.GetInt("car")!=8)
            {
                if (PlayerPrefs.GetInt("car") != 6)
                {
                    cam2.SetActive(true);
                }
                
              
            }

        }
        if (other.gameObject.CompareTag("Jump"))
        {
            rigid.constraints = RigidbodyConstraints.None;
            zombies.SetActive(false);
            bonuses.SetActive(false);
            coins.SetActive(false);
            Time.timeScale = 0.3f;

            if (tapcounter >= 7)
            {
                tap5.SetActive(true);
                
            }
            if (tapcounter >= 5)
            {
                tap4.SetActive(true);
               
            }
            if (tapcounter >= 4)
            {
                tap3.SetActive(true);
                
            }
            if (tapcounter >= 3)
            {
                tap2.SetActive(true);
               
            }
            if (tapcounter >= 2)
            {
                tap1.SetActive(true);
               
            }
            //if (tapcounter == 1)
            //{
            //    tap1.SetActive(true);

            //}
            if (tapcounter == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up*20), 200.0f * Time.deltaTime);
                speed = 0f;
                Age_Bar.GetComponent<Image>().fillAmount = 0f;
               
            }


        }
        if (other.gameObject.tag=="zombieBoss")
        {
            if (PlayerPrefs.GetInt("Vibrate") == 0)
            {
                MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            }
            bloody.transform.position = this.transform.position;
            bloody.Play();
        }
        IEnumerator Tapy()
        {
            yield return new WaitForSecondsRealtime(1.2f);
            tapbutton.SetActive(false);
        }
    }
    

}
