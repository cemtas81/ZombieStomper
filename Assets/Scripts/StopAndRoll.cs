using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StopAndRoll : MonoBehaviour
{
    FinishLine finishLine;

    public static bool isStop = false; // throwsim stop cor.

    public static bool isRotate = false;

    public GameObject target;
    public GameObject cube;

    int turnSpeed = 100;

    public Image rangeBarIn;
    public GameObject[] targetCubes;

    public GameObject RangeBar;
    public GameObject RangeBarButton;

    void Start()
    {
        finishLine = GameObject.FindObjectOfType<FinishLine>();
        isStop = false;
        isRotate = false;
    }

    void Update()
    {
        /*if (isRotate)
        {
            cube.transform.Rotate(360 * Time.deltaTime, 0, 0);
            Debug.Log(isRotate);
        }
        else
        {
            cube.transform.Rotate(0, 0, 0);
            Debug.Log(isRotate);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        isStop = true;
        

        RangeBar.SetActive(true);
        RangeBarButton.SetActive(true);

        
        Invoke("InvokeConfetti", 5.15f);
    }

    void InvokeConfetti()
    {
        if (rangeBarIn.GetComponent<Image>().fillAmount >= .2f)
        {
            RangeBarButton.SetActive(false);
            finishLine.PlayConfetti();
            Invoke("InvokeWinPanel", .75f);
        }
    }

    void InvokeWinPanel()
    {
        RangeBarButton.SetActive(false);
        finishLine.WinPanel();
    }
}
