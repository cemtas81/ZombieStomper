using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    private Button but;
    
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);

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
    }
    


}
