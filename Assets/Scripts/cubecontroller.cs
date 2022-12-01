using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;

public class cubecontroller : MonoBehaviour
{
    UpgradeScript upgradeScript;

    public Camera mainCamera;

    bool alive = true;
    bool finish = false;

    Rigidbody rb;

    float sinNumber;
    float posX;

    Vector3 cubePos;
    bool startTouch = true;

    public GameObject startButton;
    public GameObject speedButton;
    public GameObject upgradeButton;

    public GameObject bulletPrefab;
    public GameObject bulletCreate_pos;

    public GameObject Age_Bar;
    public GameObject AgeBar_Head;
    private int Age_Saver = 0;
    public GameObject[] Age_Particle;
    public GameObject Weapon_Button;
    public GameObject weapon_List;
    public GameObject NoAds_Button;
    public GameObject Shop_Button;
    public GameObject AllCoinOBJ;
    public GameObject SettingsPanel;
    public GameObject SettingsButton;
    public GameObject Settings_BlackPanel;
    public GameObject Settings_BlackPanel1;

    public Material[] Age_Materials;
    public GameObject Shoes;
    public GameObject Clothes;
    public GameObject Hair;

    public GameObject RoadOBJ;
    public GameObject GroundSpawnerOBJ;
    public GameObject GroundTileOBJ;

    public GameObject CoinCounterText;
    public GameObject failPanel;
    public GameObject winPanel;

    public GameObject SyringeButton;

    public Text coinCounterText;

    public GameObject coinText;

    float bullet_Timer = 0f;
    int oyunbasladi = 0;

    public GameObject LoadingScreen;

    private AudioSource gunFireSource;
    public AudioClip gunFireClip;

    public static int imStatic = 0;
    public static int isInternet;

    [Header("Scene Manager")]
    public GameObject Morning_Scene1;
    public GameObject Morning_Scene2;
    public GameObject Night_Scene1;
    public GameObject Night_Scene2;
    public GameObject Morning1_Sound;
    public GameObject Morning2_Sound;
    public GameObject Night1_Sound;
    public GameObject Night2_Sound;
    public GameObject First_BG;
    public GameObject Second_BG;
    public GameObject Third_BG;
    public GameObject Fourth_BG;
    public GameObject Point_Ligts;
    public GameObject DLight1;
    public GameObject DLight2;
    public GameObject DLight3;
    public GameObject StartScene;

    private void Awake()
    {
        isInternet = 1; //internet oldugunu varsayar ve 1i default alir.

        if (PlayerPrefs.GetInt("removeAd") == 1)
        {
            //GameObject.Find("AdMob").GetComponent<AdMob_Banner>().enabled = false;
            //GameObject.Find("AdMob").GetComponent<AdMob_Inter>().enabled = false;
        }
    }

    private void Start()
    {
        gunFireSource = GameObject.Find("gunfire").GetComponent<AudioSource>();

        //Application.targetFrameRate = 300;

        CheckInternetConnection();

        LoadingScreen.SetActive(false);

        oyunbasladi = 0;
        Coin.collectedCoin = 0;

        GameStart();

        RangeBar.afterKick_Start = false;
        rb = GetComponent<Rigidbody>();
        upgradeScript = GameObject.FindObjectOfType<UpgradeScript>();

        if (imStatic == 0)
            StartScene.GetComponent<StartScrene>().Start_Scene();

        if (imStatic == 0)
        {
            imStatic = 1;
        }
    }

    public void GameStart()
    {
        if (PlayerPrefs.GetInt("sahneSecim") == 0)
        {
            Morning_Scene1.SetActive(true);
            Morning1_Sound.SetActive(true);
            First_BG.SetActive(true);
            Morning_Scene2.SetActive(false);
            Night_Scene1.SetActive(false);
            Night_Scene2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 1)
        {
            Morning_Scene1.SetActive(false);
            Morning2_Sound.SetActive(true);
            Morning_Scene2.SetActive(true);
            Second_BG.SetActive(true);
            Night_Scene1.SetActive(false);
            Night_Scene2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 2)
        {
            Morning_Scene1.SetActive(false);
            Morning_Scene2.SetActive(false);
            Night1_Sound.SetActive(true);
            Night_Scene1.SetActive(true);
            Third_BG.SetActive(true);
            Night_Scene2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 3)
        {
            Morning_Scene1.SetActive(false);
            Morning_Scene2.SetActive(false);
            Night_Scene1.SetActive(false);
            Night2_Sound.SetActive(true);
            Night_Scene2.SetActive(true);
            Fourth_BG.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sahneSecim") == 4)
        {
            Morning_Scene1.SetActive(true);
            Morning1_Sound.SetActive(true);
            Morning_Scene2.SetActive(false);
            Night_Scene1.SetActive(false);
            Night_Scene2.SetActive(false);
            DLight2.SetActive(true);
            DLight1.SetActive(true);
            DLight3.SetActive(true);
            Point_Ligts.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 5)
        {
            Morning_Scene1.SetActive(false);
            Morning2_Sound.SetActive(true);
            Morning_Scene2.SetActive(true);
            Night_Scene1.SetActive(false);
            Night_Scene2.SetActive(false);
            DLight2.SetActive(true);
            DLight1.SetActive(true);
            DLight3.SetActive(true);
            Point_Ligts.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 6)
        {
            Morning_Scene1.SetActive(false);
            Morning_Scene2.SetActive(false);
            Night1_Sound.SetActive(true);
            Night_Scene1.SetActive(true);
            Night_Scene2.SetActive(false);
            DLight2.SetActive(true);
            DLight1.SetActive(true);
            DLight3.SetActive(true);
            Point_Ligts.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 7)
        {
            Morning_Scene1.SetActive(false);
            Morning_Scene2.SetActive(false);
            Night_Scene1.SetActive(false);
            Night2_Sound.SetActive(true);
            Night_Scene2.SetActive(true);
            DLight2.SetActive(true);
            DLight1.SetActive(true);
            DLight3.SetActive(true);
            Point_Ligts.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount < .25f)
        {
            AgeBar_Head.GetComponent<Animator>().SetTrigger("Start");

            /*if (Age_Saver == 2 || Age_Saver == 0)
            {
                this.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f); AgeParticle();
                Age_Saver = 3;
                Hair.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[9];
                Clothes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[10];
                Shoes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[11];
            }*/

        }
        else
            AgeBar_Head.GetComponent<Animator>().SetTrigger("Finish");

        /*else if (Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount >= .25f && Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount < .5f)
        {
            if (Age_Saver == 1 || Age_Saver == 3)
            {
                this.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                AgeParticle();
                Age_Saver = 2;
                Hair.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[6];
                Clothes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[7];
                Shoes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[8];
            }
        }
        else if (Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount >= .5f && Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount < .75f)
        {
            if (Age_Saver == 2 || Age_Saver == 0)
            {
                this.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
                AgeParticle();
                Age_Saver = 1;
                Hair.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[3];
                Clothes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[4];
                Shoes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[5];
            }
        }
        else if (Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount >= .75f)
        {
            if (Age_Saver == 1)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
                AgeParticle();
                Age_Saver = 2;
                Hair.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[0];
                Clothes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[1];
                Shoes.GetComponent<SkinnedMeshRenderer>().material = Age_Materials[2];
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;

        coinCounterText.text = Coin.collectedCoin.ToString();

        if (Input.touchCount > 0 && !finish && oyunbasladi == 1)
        {
            bullet_Timer += Time.deltaTime; //mermilerin atilmasinin süresini arttirir.
            if(bullet_Timer >= .25f) //.25 saniyeden fazlaysa mermi atar, süreyi sifirlar.
            {
                bullet_Timer = 0f;
                BulletCreation();
            }

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) //basili tutuldukca ates ve hareket eder.
            {
                float horizontal = touch.deltaPosition.x / 4f;

                sinNumber += Time.deltaTime * 2;

                float sinTemp = Mathf.Sin(sinNumber) / 500;
                posX += horizontal * Time.deltaTime;
                posX = Mathf.Clamp(posX, -3f, 3.95f);
                cubePos = new Vector3(posX, transform.position.y, transform.position.z);
                transform.position = cubePos;

                //clamp, or whatever
            }
        }
        else
            bullet_Timer = 0f; //el ekrandan kalkınca ateş etme durur.
    }

    private void LateUpdate()
    {
        if(!RangeBar.afterKick_Start) //karakter boss a geldiginde bar doldurma suresi bitince camera karakter takibini birakir.
            mainCamera.transform.position = new Vector3(0.49f, 8.25f, this.transform.position.z - 13.51f);
    }

    public void Die()
    {
        alive = false;
        failPanel.SetActive(true);
        Settings_BlackPanel1.SetActive(true);
        coinText.SetActive(false);
        Age_Bar.SetActive(false);
        AgeBar_Head.SetActive(false);
        SyringeButton.SetActive(false);
        finish = true;
        this.GetComponent<Animator>().SetTrigger("kick_start");
        RoadOBJ.SetActive(true);
        GroundTileOBJ.SetActive(false);
        //Restart the game
        //Invoke("Restart", 2f);
    }

    public void Restart()
    {
        if (PlayerPrefs.GetInt("removeAd") == 0)
        {
            //if (isInternet == 1)
            //    GameObject.Find("AdMob").GetComponent<AdMob_Inter>().ShowInterstitial();

            failPanel.SetActive(false);
            Invoke("DestroyAdmobs", 1f);
        }
        else
        {
            failPanel.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

    public void DestroyAdmobs()
    {
        //GameObject.Find("AdMob").GetComponent<AdMob_Banner>().Banner_Destroy();
        //GameObject.Find("AdMob").GetComponent<AdMob_Inter>().InterDestroy();
        SceneManager.LoadScene(0);
    }

    public void Next_Level()
    {
        if(PlayerPrefs.GetInt("removeAd") == 0)
            if (isInternet == 1)
                //GameObject.Find("AdMob").GetComponent<AdMob_Inter>().ShowInterstitial();

        winPanel.SetActive(false);
        Invoke("Invoke_NextLevel", 1);
    }

    public void Invoke_NextLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        if (PlayerPrefs.GetInt("sahneSecim") == 0)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 1);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 1)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 2);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 2)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 3);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 3)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 4);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 4)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 5);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 5)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 6);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 6)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 7);
        }
        else if (PlayerPrefs.GetInt("sahneSecim") == 7)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("sahneSecim", 0);
        }

        if (PlayerPrefs.GetInt("removeAd") == 0)
        {
            //GameObject.Find("AdMob").GetComponent<AdMob_Banner>().Banner_Destroy();
            //GameObject.Find("AdMob").GetComponent<AdMob_Inter>().InterDestroy();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        oyunbasladi = 1;
        this.GetComponent<Animator>().SetTrigger("start_game");

        SyringeButton.SetActive(true);

        coinText.SetActive(true);
        Age_Bar.SetActive(true);
        AgeBar_Head.SetActive(true);
        GroundSpawnerOBJ.SetActive(true);
        weapon_List.SetActive(false);

        RoadOBJ.SetActive(false);
        Weapon_Button.SetActive(false);
        NoAds_Button.SetActive(false);
        Shop_Button.SetActive(false);
        SettingsButton.SetActive(false);
        AllCoinOBJ.SetActive(false);

        //rb.velocity = new Vector3(0, 0, 12);
        //speedButton.SetActive(true);
        startButton.SetActive(false);
        upgradeButton.SetActive(false);
        //StartCoroutine("DeclarationMovement");
        for (int i = 0; i < (int)(PlayerPrefs.GetFloat("firstX")/.2f)+10; i++)
        {
            upgradeScript.SpawnMultipleGround();
        }

        
    }

    public void FinishGame()
    {
        rb.velocity = new Vector3(0, 0, 0);
        finish = true;
    }

    IEnumerator DeclarationMovement()
    {
        while(rb.velocity.z >= 0)
        {
            rb.velocity = new Vector3(0, 0, rb.velocity.z - .25f);
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    public void BulletCreation() //merminin olusturulmasi.
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        gunFireSource.PlayOneShot(gunFireClip, .2f);
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletCreate_pos.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20); //merminin gidicegi hiz.
        Destroy(bullet, 1.5f);
    }

    public void IncreaseMovement()
    {
        rb.velocity = new Vector3(0, 0, rb.velocity.z + .25f);
    }

    void AgeParticle() //agebar aralıklarında bulut particle calistirir.
    {
        for (int i = 0; i < 3; i++)
        {
            Age_Particle[i].GetComponent<ParticleSystem>().Play();
        }
    }

    public void BossFight()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(1);
    }

    private void CheckInternetConnection()
    {
        StartCoroutine(CheckRoutine());
    }

    private IEnumerator CheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(10f);
            WWW request = new WWW("google.com");
            float elapsedTime = 0.0f;

            while (!request.isDone)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= 10f && request.progress <= .5f)
                {
                    break;
                }
                yield return null;
            }

            if (!request.isDone || !string.IsNullOrEmpty(request.error))
                isInternet = 0;
            else
                isInternet = 1;

            Debug.Log("internet :" + isInternet);
        }
    }
}
