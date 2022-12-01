using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;

public class UpgradeScript : MonoBehaviour
{
    public Text UpgradeNumberText;
    public Text UpgradePriceText;
    public Text AllConText;
    public Text weaponLevel;
    public Text weaponPrice;
    GameObject temp;

    public static int xMaterial;
    public Material[] xMaterials;
    public Sprite[] WeaponIMGs;

    public GameObject weaponIMG;
    public GameObject weaponOBJ;
    public GameObject weaponOBJ_startScene;

    public GameObject weaponBuy_Open;
    public GameObject weaponBuy_Close;

    public GameObject MultipleBuy_Open;
    public GameObject MultipleBuy_Close;

    public GameObject MultipleGround;

    public GameObject Admob;

    Vector3 nextSpawnPoint = new Vector3(0,0,305.5f);

    public GameObject AnimMenu_Items;

    bool isOpen_Weapon;
    bool isOpen_Upgrade;

    [Header("Weapon Button")]
    public GameObject[] weaponButton;
    public GameObject weaponList_Button;
    public Sprite buttonActive;
    public Sprite button_Dactive;

    [Header("Settings Button")]
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibOn;
    public GameObject vibOff;
    public GameObject settings_panel;
    bool isOpen_Settings;

    void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            AudioListener.volume = 1;
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }

        if (PlayerPrefs.GetInt("vibrate") == 0)
        {
            MMVibrationManager.SetHapticsActive(true);
            vibOn.SetActive(true);
            vibOff.SetActive(false);
        }
        else
        {
            MMVibrationManager.SetHapticsActive(false);
            vibOn.SetActive(false);
            vibOff.SetActive(true);
        }
        isOpen_Settings = false;
        isOpen_Weapon = false;
        isOpen_Upgrade = false;

        Random.seed = PlayerPrefs.GetInt("level");

        xMaterial = 0;
        WeaponLevels();

        PlayerPrefs.SetFloat("xCounter", 1.0f);

        if (PlayerPrefs.GetInt("firstBuy") == 0)
        {
            PlayerPrefs.SetInt("firstBuy", 1);
            PlayerPrefs.SetFloat("firstX", 2.0f);
            PlayerPrefs.SetInt("firstPrice", 100);
            PlayerPrefs.SetInt("weaponPrice", 100);
        }
    }

    public void SpawnMultipleGround()
    {
        temp = Instantiate(MultipleGround, nextSpawnPoint,Quaternion.identity);
        temp.transform.SetParent(this.transform);
        temp.GetComponent<MeshRenderer>().material = xMaterials[xMaterial];
        xMaterial++;
        if (xMaterial == 10)
            xMaterial = 0;
        nextSpawnPoint = temp.transform.GetChild(0).position;
        temp.transform.GetChild(1).GetComponent<TextMesh>().text = "X " + PlayerPrefs.GetFloat("xCounter").ToString(".0");
        PlayerPrefs.SetFloat("xCounter", PlayerPrefs.GetFloat("xCounter") + .2f);
    }

    void FixedUpdate()
    {
        UpgradeNumberText.text = "X" + PlayerPrefs.GetFloat("firstX").ToString(".0");
        UpgradePriceText.text = PlayerPrefs.GetInt("firstPrice").ToString();
        AllConText.text = PlayerPrefs.GetInt("allCoin").ToString();
        weaponPrice.text = PlayerPrefs.GetInt("weaponPrice").ToString();
        weaponLevel.text = "Lv" + PlayerPrefs.GetInt("weaponLevel").ToString();

        if (PlayerPrefs.GetInt("allCoin") >= PlayerPrefs.GetInt("weaponPrice"))
        {
            weaponBuy_Open.SetActive(true);
            weaponBuy_Close.SetActive(false);
        }
        else
        {
            weaponBuy_Open.SetActive(false);
            weaponBuy_Close.SetActive(true);
        }

        if (PlayerPrefs.GetInt("allCoin") >= PlayerPrefs.GetInt("firstPrice"))
        {
            MultipleBuy_Open.SetActive(true);
            MultipleBuy_Close.SetActive(false);
        }
        else
        {
            MultipleBuy_Open.SetActive(false);
            MultipleBuy_Close.SetActive(true);
        }

        for (int i = PlayerPrefs.GetInt("weapon"); i < weaponButton.Length; i++)
        {
            weaponButton[i].GetComponent<Image>().sprite = button_Dactive;
            weaponButton[PlayerPrefs.GetInt("weapon")].GetComponent<Image>().sprite = buttonActive;
        }

        for (int j = 1; j < weaponButton.Length; j++)
        {
            weaponButton[j].transform.GetChild(1).GetComponent<Text>().text = "Lv" + 5 * j;
        }
    }

    public void UpgradeMultiple()
    {
        weaponList_Button.SetActive(false);
        settings_panel.SetActive(false);

        AnimMenu_Items.SetActive(true);

        isOpen_Settings = false;
        isOpen_Weapon = false;

        if (PlayerPrefs.GetInt("allCoin") >= PlayerPrefs.GetInt("firstPrice"))
        {
            UpgradeNumberText.GetComponent<Animator>().SetTrigger("upgrade");
            PlayerPrefs.SetInt("allCoin", (PlayerPrefs.GetInt("allCoin") - PlayerPrefs.GetInt("firstPrice")));
            PlayerPrefs.SetFloat("firstX", PlayerPrefs.GetFloat("firstX") + .6f);
            PlayerPrefs.SetInt("firstPrice", PlayerPrefs.GetInt("firstPrice") + 70);
        }
        else
        {
//            Admob.GetComponent<AdMob_Reward>().UserChoseToWatchAd4();
        }
    }

    public void WeaponUpgrade()
    {
        weaponList_Button.SetActive(true);
        settings_panel.SetActive(false);

        AnimMenu_Items.SetActive(false);

        isOpen_Settings = false;
        isOpen_Weapon = true;

        if (PlayerPrefs.GetInt("allCoin") >= PlayerPrefs.GetInt("weaponPrice"))
        {
            weaponLevel.GetComponent<Animator>().SetTrigger("upgrade");
            PlayerPrefs.SetInt("weaponLevel", PlayerPrefs.GetInt("weaponLevel") + 1);
            PlayerPrefs.SetInt("allCoin", (PlayerPrefs.GetInt("allCoin") - PlayerPrefs.GetInt("weaponPrice")));
            PlayerPrefs.SetInt("weaponPrice", PlayerPrefs.GetInt("weaponPrice") + 45);
            WeaponLevels();
        }
        else
        {
           // Admob.GetComponent<AdMob_Reward>().UserChoseToWatchAd3();
        }

    }

    void WeaponLevels()
    {
        weaponLevel.text = "Lv"+PlayerPrefs.GetInt("weaponLevel").ToString();

        if (PlayerPrefs.GetInt("weaponLevel") >= 5 && PlayerPrefs.GetInt("weaponLevel") < 10)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[1];
            PlayerPrefs.SetInt("weapon", 1);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 10 && PlayerPrefs.GetInt("weaponLevel") < 15)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[2];
            PlayerPrefs.SetInt("weapon", 2);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 15 && PlayerPrefs.GetInt("weaponLevel") < 20)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[3];
            PlayerPrefs.SetInt("weapon", 3);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 20 && PlayerPrefs.GetInt("weaponLevel") < 25)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[4];
            PlayerPrefs.SetInt("weapon", 4);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 25 && PlayerPrefs.GetInt("weaponLevel") < 30)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[5];
            PlayerPrefs.SetInt("weapon", 5);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 30 && PlayerPrefs.GetInt("weaponLevel") < 35)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[6];
            PlayerPrefs.SetInt("weapon", 6);
        }
        else if (PlayerPrefs.GetInt("weaponLevel") >= 35)
        {
            weaponIMG.GetComponent<Image>().sprite = WeaponIMGs[7];
            PlayerPrefs.SetInt("weapon", 7);
        }
        else if(PlayerPrefs.GetInt("weaponLevel") < 5)
        {
            PlayerPrefs.SetInt("weapon", 0);
        }

        for (int j = 0; j < weaponOBJ.transform.childCount; j++)
        {
            if (PlayerPrefs.GetInt("weapon") == j)
            {
                weaponOBJ.transform.GetChild(j).gameObject.SetActive(true);
                weaponOBJ_startScene.transform.GetChild(j).gameObject.SetActive(true);
            }
            else
            {
                weaponOBJ.transform.GetChild(j).gameObject.SetActive(false);
                weaponOBJ_startScene.transform.GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    public void OpenSettings()
    {
        weaponList_Button.SetActive(false);

        if (isOpen_Settings == false)
        {
            settings_panel.SetActive(true);
            isOpen_Settings = true;
            isOpen_Weapon = false;
            AnimMenu_Items.SetActive(false);
        }

        else
        {
            AnimMenu_Items.SetActive(true);
            settings_panel.SetActive(false);
            isOpen_Settings = false;
            isOpen_Weapon = false;
        }
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("sound", 0);
        AudioListener.volume = 1;
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("sound", 1);
        AudioListener.volume = 0;
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }

    public void VibOn()
    {
        PlayerPrefs.SetInt("vibrate", 0);
        MMVibrationManager.SetHapticsActive(true);
        vibOn.SetActive(true);
        vibOff.SetActive(false);
    }

    public void VibOff()
    {
        PlayerPrefs.SetInt("vibrate", 1);
        MMVibrationManager.SetHapticsActive(false);
        vibOn.SetActive(false);
        vibOff.SetActive(true);
    }
}
