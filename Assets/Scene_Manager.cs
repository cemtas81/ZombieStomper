using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("sahneSecim") == 2 || PlayerPrefs.GetInt("sahneSecim") == 3)
            SceneManager.LoadScene(1);
    }
}
