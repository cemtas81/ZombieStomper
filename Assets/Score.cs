using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    public string sco;
   
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        sco = score.ToString();
       
        PlayerPrefs.GetString("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString ("HighScore", sco);
             
    }
}
