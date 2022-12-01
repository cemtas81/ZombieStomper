using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Button but;
    public int level;

    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
        level = PlayerPrefs.GetInt("next");
    }
    private void OnEnable()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        this.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("next")<5)
        {
            PlayerPrefs.SetInt("next", PlayerPrefs.GetInt("next") + 1);
        }
        if(PlayerPrefs.GetInt("next")>=5)
        {
            PlayerPrefs.SetInt("next", 0);
        }

    }

}
