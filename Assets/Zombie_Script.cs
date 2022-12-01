using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Zombie_Script : MonoBehaviour
{
    public Text Health_Text;
    int Zombie_Health;
    public GameObject RestartButton;

    float bullet_Timer;

    public static float timer;
    public static float timer2;

    public GameObject Zombie_HealthBar;
    float health;
    public Material[] skyboxMats;

    public GameObject gainCoin;
    public GameObject gainCoin_LastPos;
    public GameObject gainCoin_StartPos1;
    public GameObject gainCoin_StartPos2;
    public GameObject gainCoin_StartPos3;
    public GameObject gainCoin_StartPos4;
    public GameObject coinSound;
    public static bool gameWin = false;
    int saydir = 0;

    [Header("Boss Start Screen")]
    public Text[] levelText;
    public Text[] zombieHealth;
    public Text[] collectedCoin;
    public Image[] bossIMGs;
    public Sprite[] greyBossIMGs;
    public Image[] aboutBoss_BG;
    public Sprite greyAboutBossBG;
    public GameObject[] lockTexts;
    public GameObject[] lockOBJs;
    public Text allCoin_Text;
    public GameObject[] Bosses;
    public GameObject root;
    public static int Boss_LevelHealth;
    public GameObject fightButton;
    public static bool isGameStart = false;
    public GameObject LoadingScreen;

    [Header("Game Screen")]
    public GameObject level1_Props;
    public GameObject level2_Props;
    public GameObject level3_Props;
    public GameObject level3Items;
    public GameObject level4Items;
    public GameObject level4Items2;
    public GameObject level4L1;
    public GameObject level4L2;
    public GameObject level4L3;
    public GameObject zombie2;

    [Header("Failed Screen")]
    public GameObject failedPanel;
    bool isFail = false;

    [Header("Win Panel")]
    public GameObject confettiEffect;
    bool isWin = false;

    private void Start()
    {
        LoadingScreen.SetActive(false);

        //if (PlayerPrefs.GetInt("removeAd") == 1)
        //{
        //    GameObject.Find("AdMob").GetComponent<AdMob_Banner>().enabled = false;
        //}

        isWin = false;
        isFail = false;
        isGameStart = false;

        saydir = 0;

        if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 21)
            fightButton.GetComponent<Button>().interactable = false;

        allCoin_Text.text = PlayerPrefs.GetInt("allCoin").ToString();

        if (PlayerPrefs.GetInt("BossGame_Level") + 1 <= 5)
        {
            level1_Props.SetActive(true);
            Bosses[0].SetActive(true);

            for (int i = 1; i < 4; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;

                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }
            levelText[0].text = "Lvl" + "\n" + (PlayerPrefs.GetInt("new_BossGame_Level1") + 1) + "/" + "5";
            zombieHealth[0].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)) + " / " + ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f));
            collectedCoin[0].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)).ToString();
            RenderSettings.skybox = skyboxMats[0];
        }
        else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 6 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 10)
        {
            level2_Props.SetActive(true);
            Bosses[1].SetActive(true);

            bossIMGs[0].GetComponent<Image>().sprite = greyBossIMGs[0];
            aboutBoss_BG[0].GetComponent<Image>().sprite = greyAboutBossBG;
            lockTexts[0].GetComponent<Text>().text = "COMPLETED!";
            lockOBJs[0].SetActive(false);
            lockTexts[0].SetActive(true);

            for (int i = 2; i < 4; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;

                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }
            levelText[1].text = "Lvl" + "\n" + (PlayerPrefs.GetInt("new_BossGame_Level2") + 1) + "/" + "5";
            zombieHealth[1].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)) + " / " + ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f));
            collectedCoin[1].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)).ToString();
            RenderSettings.skybox = skyboxMats[1];

        }
        else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 11 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 15)
        {
            level3_Props.SetActive(true);
            level3Items.SetActive(true);
            Bosses[2].SetActive(true);
            root.SetActive(false);

            for (int i = 0; i < 2; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;
                lockTexts[i].GetComponent<Text>().text = "COMPLETED!";
                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }

            for (int i = 3; i < 4; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;

                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }
            levelText[2].text = "Lvl" + "\n" + (PlayerPrefs.GetInt("new_BossGame_Level3") + 1) + "/" + "5";
            zombieHealth[2].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)) + " / " + ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f));
            collectedCoin[2].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)).ToString();
            RenderSettings.skybox = skyboxMats[2];
        }
        else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 16 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 20)
        {
            level2_Props.SetActive(true);
            level4Items.SetActive(true);
            Bosses[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;
                lockTexts[i].GetComponent<Text>().text = "COMPLETED!";
                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }

            levelText[3].text = "Lvl" + "\n" + (PlayerPrefs.GetInt("new_BossGame_Level4") + 1) + "/" + "5";
            zombieHealth[3].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)) + " / " + ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f));
            collectedCoin[3].text = ((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f)).ToString();
            RenderSettings.skybox = skyboxMats[3];
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                bossIMGs[i].GetComponent<Image>().sprite = greyBossIMGs[i];
                aboutBoss_BG[i].GetComponent<Image>().sprite = greyAboutBossBG;
                lockTexts[i].GetComponent<Text>().text = "COMPLETED!";
                lockOBJs[i].SetActive(false);
                lockTexts[i].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("ZombieLevel") == 0)
        {
            if (PlayerPrefs.GetInt("BossGame_Level") == 0)
                Zombie_Health = 249;
            else
                Zombie_Health = (int)((300 * (PlayerPrefs.GetInt("BossGame_Level2") + 1)) / 1.2f);

            Boss_LevelHealth = Zombie_Health;
            PlayerPrefs.SetInt("Boss_LevelHealth", Zombie_Health);
        }
        else
        {
            Zombie_Health = PlayerPrefs.GetInt("Boss_LastHealth");
            for (int i = 0; i < 4; i++)
            {
                zombieHealth[i].text = Zombie_Health + " / " + ((int)((300 * ((PlayerPrefs.GetInt("BossGame_Level2") + 1))) / 1.2f));
            }
            Debug.Log((float)Zombie_Health / Boss_LevelHealth);
            Debug.Log("icerdeyim");
        }

        Time.timeScale = 1;

        Zombie_HealthBar.GetComponent<Image>().fillAmount = (float)Zombie_Health / PlayerPrefs.GetInt("Boss_LevelHealth");

        Health_Text.text = Zombie_Health.ToString();

        Invoke("Invoke_CoinMove", 2f);
    }

    public void Invoke_Particles()
    {
        if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 16 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 20)
        {
            Invoke("Invoke_Lightnin1", 5);
            Invoke("Invoke_Lightnin2", 10);
            Invoke("Invoke_Lightnin3", 15);
        }
    }

    public void Invoke_Lightnin1()
    {
        level4L1.SetActive(true);
    }

    public void Invoke_Lightning2()
    {
        level4L2.SetActive(true);
    }

    public void Invoke_Lightning3()
    {
        level4L3.SetActive(true);
    }

    void Invoke_CoinMove()
    {
        if (gameWin)
        {
            StartCoroutine("Wait_Instantiete");
            coinSound.SetActive(true);
            gameWin = false;
        }
    }

    IEnumerator Wait_Instantiete()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (PlayerPrefs.GetInt("BossGame_Level") + 1 <= 6)
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(.1f);

                    GameObject coinObj = Instantiate(gainCoin, allCoin_Text.transform);
                    coinObj.transform.position = gainCoin_StartPos1.transform.position;
                    coinObj.transform.DOMove(gainCoin_LastPos.transform.position, .5f).OnComplete(() => Destroy(coinObj.gameObject));
                    saydir++;
                }
            }
            else if (PlayerPrefs.GetInt("BossGame_Level") + 1 > 6 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 11)
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(.1f);

                    GameObject coinObj = Instantiate(gainCoin, allCoin_Text.transform);
                    coinObj.transform.position = gainCoin_StartPos2.transform.position;
                    coinObj.transform.DOMove(gainCoin_LastPos.transform.position, .5f).OnComplete(() => Destroy(coinObj.gameObject));
                    saydir++;
                }
            }
            else if (PlayerPrefs.GetInt("BossGame_Level") + 1 > 11 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 16)
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(.1f);

                    GameObject coinObj = Instantiate(gainCoin, allCoin_Text.transform);
                    coinObj.transform.position = gainCoin_StartPos3.transform.position;
                    coinObj.transform.DOMove(gainCoin_LastPos.transform.position, .5f).OnComplete(() => Destroy(coinObj.gameObject));
                    saydir++;
                }
            }
            else if (PlayerPrefs.GetInt("BossGame_Level") + 1 > 16 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 21)
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(.1f);

                    GameObject coinObj = Instantiate(gainCoin, allCoin_Text.transform);
                    coinObj.transform.position = gainCoin_StartPos4.transform.position;
                    coinObj.transform.DOMove(gainCoin_LastPos.transform.position, .5f).OnComplete(() => Destroy(coinObj.gameObject));
                    saydir++;
                }
            }
            if (saydir >= 5)
            {
                StopCoroutine("Wait_Instantiete");
                if (PlayerPrefs.GetInt("BossGame_Level") != 0 && PlayerPrefs.GetInt("BossGame_Level2") == 0)
                {

                    PlayerPrefs.SetInt("allCoin", PlayerPrefs.GetInt("allCoin") + (((int)((300 * (5)) / 1.2f))));
                }
                else
                    PlayerPrefs.SetInt("allCoin", PlayerPrefs.GetInt("allCoin") + (((int)((300 * (PlayerPrefs.GetInt("BossGame_Level2"))) / 1.2f))));

                allCoin_Text.text = PlayerPrefs.GetInt("allCoin").ToString();
                allCoin_Text.GetComponent<Animator>().SetTrigger("trigger");
            }
        }
    }

    private void Update()
    {
        if (Zombie_Health <= 0)
        {
            gameWin = true;

            if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 11 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 15)
                zombie2.GetComponent<Animator>().SetTrigger("Die");
            else
                this.GetComponent<Animator>().SetTrigger("Die");

            //Time.timeScale = 0;
            confettiEffect.SetActive(true);
            Zombie_HealthBar.SetActive(false);

            PlayerPrefs.SetInt("ZombieLevel", 0);

            if (!isWin)
            {
                if (PlayerPrefs.GetInt("BossGame_Level") + 1 <= 5)
                {
                    if(PlayerPrefs.GetInt("BossGame_Level") + 1 == 5)
                        PlayerPrefs.SetInt("BossGame_Level2", 0);
                    else
                        PlayerPrefs.SetInt("BossGame_Level2", (PlayerPrefs.GetInt("BossGame_Level2") + 1));

                    PlayerPrefs.SetInt("BossGame_Level", (PlayerPrefs.GetInt("BossGame_Level") + 1));
                    PlayerPrefs.SetInt("new_BossGame_Level1", (PlayerPrefs.GetInt("new_BossGame_Level1") + 1));
                }
                else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 6 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 10)
                {
                    if (PlayerPrefs.GetInt("BossGame_Level") + 1 == 10)
                        PlayerPrefs.SetInt("BossGame_Level2", 0);
                    else
                        PlayerPrefs.SetInt("BossGame_Level2", (PlayerPrefs.GetInt("BossGame_Level2") + 1));

                    PlayerPrefs.SetInt("BossGame_Level", (PlayerPrefs.GetInt("BossGame_Level") + 1));
                    PlayerPrefs.SetInt("new_BossGame_Level2", (PlayerPrefs.GetInt("new_BossGame_Level2") + 1));
                }
                else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 11 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 15)
                {
                    if (PlayerPrefs.GetInt("BossGame_Level") + 1 == 15)
                        PlayerPrefs.SetInt("BossGame_Level2", 0);
                    else
                        PlayerPrefs.SetInt("BossGame_Level2", (PlayerPrefs.GetInt("BossGame_Level2") + 1));

                    PlayerPrefs.SetInt("BossGame_Level", (PlayerPrefs.GetInt("BossGame_Level") + 1));
                    PlayerPrefs.SetInt("new_BossGame_Level3", (PlayerPrefs.GetInt("new_BossGame_Level3") + 1));
                }
                else if (PlayerPrefs.GetInt("BossGame_Level") + 1 >= 16 && PlayerPrefs.GetInt("BossGame_Level") + 1 <= 20)
                {
                    if (PlayerPrefs.GetInt("BossGame_Level") + 1 == 20)
                        PlayerPrefs.SetInt("BossGame_Level2", 0);
                    else
                        PlayerPrefs.SetInt("BossGame_Level2", (PlayerPrefs.GetInt("BossGame_Level2") + 1));

                    PlayerPrefs.SetInt("BossGame_Level", (PlayerPrefs.GetInt("BossGame_Level") + 1));
                    PlayerPrefs.SetInt("new_BossGame_Level4", (PlayerPrefs.GetInt("new_BossGame_Level4") + 1));
                }

                isWin = true;
            }
            Invoke("Invoke_SceneLoad", 2.5f);
        }

        if (isGameStart)
        {
            if (Input.touchCount > 0)
            {
                bullet_Timer += Time.deltaTime; //mermilerin atilmasinin süresini arttirir.
                if (bullet_Timer >= .1f) //.1 saniyeden fazlaysa mermi atar, süreyi sifirlar.
                {
                    bullet_Timer = 0f;
                    GameObject.Find("SM_Wep_AAGun_Swivel_01").GetComponent<SwipeRotationPlayer>().Bullet_Creation();
                }
            }
        }
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Zombie_Health -= 2;
            Health_Text.text = Zombie_Health.ToString();

            Zombie_HealthBar.GetComponent<Image>().fillAmount = (float)Zombie_Health / PlayerPrefs.GetInt("Boss_LevelHealth");

            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "ZombieTrigger")
        {
            failedPanel.SetActive(true);
            Zombie_HealthBar.SetActive(false);

            PlayerPrefs.SetInt("ZombieLevel", 1);

            if (!isFail)
                PlayerPrefs.SetInt("Boss_LastHealth", Zombie_Health);

            Invoke("Invoke_SceneLoad", 2.5f);
        }
    }

    private void Invoke_SceneLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseButton()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
