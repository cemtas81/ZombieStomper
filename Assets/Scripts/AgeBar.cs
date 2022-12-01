using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeBar : MonoBehaviour
{
    cubecontroller cubecontroller;

    float time = 0f;

    public GameObject Age_Bar;
    public GameObject Karakter_Bar;

    public Color[] myColor;
    int colorIndex = 0;

    private void Start()
    {
        //cubecontroller = GameObject.FindObjectOfType<cubecontroller>();
    }

    void Update()
    {
        //time += Time.deltaTime;
        //if(time >= .2f)
        //{
        //    time = 0;
        //    Age_Bar.GetComponent<Image>().fillAmount -= 0.01f;
        //}

        ///*if(Obstacle.killZombie == 1)
        //{
        //    Obstacle.killZombie = 0;
        //    Age_Bar.GetComponent<Image>().fillAmount += 0.04f;
        //}*/

        //if(Age_Bar.GetComponent<Image>().fillAmount <= 0)
        //{
        //    cubecontroller.Die();
        //    cubecontroller.FinishGame();
        //}

        LerpColor();
    }

    void LerpColor()
    {
        Color healthColor = Color.Lerp(myColor[0], myColor[colorIndex] ,(Age_Bar.GetComponent<Image>().fillAmount / 1));
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
