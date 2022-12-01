using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void ClickBuy()
    {
        IAP_Manager.Instance.BuyNoAds();
    }
}
