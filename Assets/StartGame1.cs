using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame1 : MonoBehaviour
{
   
    private Button but;
    public GameObject pause;

    void Start()
    {
       
        //Time.timeScale = 0f;
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
        
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        pause.SetActive(true);
    }
}
