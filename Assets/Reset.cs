using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    private Button but;

    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        PlayerPrefs.DeleteAll();
    }

  
}
