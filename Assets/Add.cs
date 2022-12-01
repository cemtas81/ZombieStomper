using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Add : MonoBehaviour
{
    public Text addx3;
    private Button but;
    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(add);
        //addx3=
    }

    void add()
    {

    }
}
