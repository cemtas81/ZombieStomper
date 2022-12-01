using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Common;
using GoogleMobileAds.Api;
using UnityEngine.Events;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    private RewardedAd rAd;
    public float finalcoin;
    public Text coinfinal;
    public int odulAlindi = 0;
    int secim = 0;
    public Button but;
    public GameObject adbut;
    
    // Start is called before the first frame update
    [Obsolete]
    public void Start()
    {
        but.onClick.AddListener(Add);
        string adUnitId;
        #if UNITY_ANDROID
                adUnitId = "ca-app-pub-9585813676258300/9644503885";
#elif UNITY_IPHONE
                    adUnitId = "ca-app-pub-9585813676258300/6143408429";
#else
                    adUnitId = "unexpected_platform";
#endif
        MobileAds.Initialize(InitializationStatus => { });
        but = GetComponent<Button>();
        this.rAd = new RewardedAd(adUnitId);
        odulAlindi = 0;
        // Called when an ad request has successfully loaded.
        this.rAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        //this.rAd.OnUserEarnedReward += HandleUserEarnedReward;
        //// Called when the ad is closed.
        this.rAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.rAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //MonoBehaviour.print(
        //    "HandleRewardedAdFailedToLoad event received with message: "
        //                     + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
        
    }

    [Obsolete]
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        //PlayerPrefs.SetFloat("collected", PlayerPrefs.GetFloat("collected") - 3000f);

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        //MonoBehaviour.print("HandleRewardedAdRewarded event received for " + amount.ToString() + "3000 " + type);
        odulAlindi = 1;

    }
    //public void UserChoseToWatchAd()
    //{
    //    if (this.rAd.IsLoaded())
    //    {
    //        this.rAd.Show();
    //        odulAlindi = 1;
    //    }
    //    adbut.gameObject.SetActive(false);
    //}
    void Add()
    {
        if (this.rAd.IsLoaded())
        {
            this.rAd.Show();
           
        }

        adbut.gameObject.SetActive(false);

    }



}
