using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject v;
    public GameObject p;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            p.SetActive(true);

        }
        else
        {
            p.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Vibrate") == 0)
        {
            v.SetActive(true);
        }
        else
        {
            v.SetActive(false);
        }
    }

    
}
