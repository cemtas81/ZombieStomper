using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillingBar : MonoBehaviour
{
    Image fillBarImage;
    Text percentText;
    public static float thisPercent;

    void Start()
    {
        thisPercent = 0;
        fillBarImage = GetComponent<Image>();
        percentText = transform.GetChild(0).GetComponent<Text>();
    }

    public void FillBar(float fillinCount,float percent)
    {
        fillBarImage.fillAmount += fillinCount;
        thisPercent += percent;
        percentText.text = "%" + thisPercent.ToString(".0");
    }
}
