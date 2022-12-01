using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : Singleton<DataManager>
{
    public GameObject noAdsButton;
    public GameObject adMob;    

    private void Start()
    {
        if (PlayerPrefs.GetInt("removeAd") == 1)
            noAdsButton.SetActive(false);
    }

    public void RemoveAds()
    {
        PlayerPrefs.SetInt("removeAd", 1);
        noAdsButton.SetActive(false);
        //adMob.GetComponent<AdMob_Banner>().enabled = false;
        //adMob.GetComponent<AdMob_Inter>().enabled = false;
        //adMob.GetComponent<AdMob_Banner>().Banner_Destroy();
        //adMob.GetComponent<AdMob_Inter>().InterDestroy();
    }
}
