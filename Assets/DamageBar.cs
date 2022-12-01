using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageBar : MonoBehaviour
{
    public GameObject Age_Bar;
    public GameObject Karakter_Bar;

    public Color[] myColor;
    int colorIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Age_Bar.GetComponent<Image>().fillAmount = 1f;
        //Karakter_Bar.GetComponent<Image>().color = 
    }

    // Update is called once per frame
    void Update()
    {
        LerpColor();
        
    }
    void LerpColor()
    {
        Color healthColor = Color.Lerp(myColor[0], myColor[colorIndex], (Age_Bar.GetComponent<Image>().fillAmount / 1));
        Age_Bar.GetComponent<Image>().color = healthColor;
        Karakter_Bar.GetComponent<Image>().color = healthColor;

        if (Age_Bar.GetComponent<Image>().fillAmount < .25f)
            colorIndex = 0;
        else if (Age_Bar.GetComponent<Image>().fillAmount >= .25f && Age_Bar.GetComponent<Image>().fillAmount < .5f)
            colorIndex = 1;
        else if (Age_Bar.GetComponent<Image>().fillAmount >= .5f && Age_Bar.GetComponent<Image>().fillAmount < .75f)
            colorIndex = 2;
        else if (Age_Bar.GetComponent<Image>().fillAmount >= .75f)
            colorIndex = 3;
    }
}
