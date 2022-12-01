using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScrene : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject startCamera;

    public GameObject directLight1;
    public GameObject directLight2;

    public GameObject pointLight;

    public GameObject[] closePrefab;
    public GameObject openPrefab;

    public GameObject karakter;

    public GameObject goldMagnet;
    public GameObject healthMagnet;
    public GameObject bossButton;

    public void Start_Scene()
    {
        mainCamera.SetActive(false);
        startCamera.SetActive(true);
        directLight1.SetActive(false);
        directLight2.SetActive(false);
        pointLight.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            closePrefab[i].SetActive(false);
        }

        openPrefab.SetActive(true);
        karakter.SetActive(true);
    }

    public void Start_Button()
    {
        GameObject.Find("Cube").GetComponent<cubecontroller>().StartGame();
        GameObject.Find("Cube").GetComponent<cubecontroller>().GameStart();

        goldMagnet.SetActive(false);
        healthMagnet.SetActive(false);
        bossButton.SetActive(false);

        karakter.SetActive(false);
        mainCamera.SetActive(true);
        startCamera.SetActive(false);
    }
}
