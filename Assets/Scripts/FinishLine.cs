using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject[] confettiArray;
    [SerializeField] GameObject winPanel;
    //[SerializeField] GameObject RangeBar;
    public GameObject cube;
    public GameObject target;
    public GameObject NoThanks_Button;
    public GameObject winPanel_BlackPanel;

    public Text nothanks_Coin;
    public Text multiple_Coin; 

    public GameObject Age_Bar;
    public GameObject AgeBar_Head;

    public GameObject Syringe;

    cubecontroller Cubecontroller;
    ThrowSimulation throwSimulation;

    private void Start()
    {
        Cubecontroller = GameObject.FindObjectOfType<cubecontroller>();
        throwSimulation = GameObject.FindObjectOfType<ThrowSimulation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Syringe.SetActive(false);

        if (other.gameObject.name == "Cube")
        {
            cube.transform.position = new Vector3(0, 0, 298);
            target.transform.rotation = Quaternion.Euler(0, 180, 0);
            target.transform.GetComponent<Animator>().SetTrigger("kick_start");
            Age_Bar.SetActive(false);
            AgeBar_Head.SetActive(false);
            cube.GetComponent<Animator>().SetTrigger("kick_start");
            Cubecontroller.FinishGame();
        }
    }

    public void PlayConfetti()
    {
        confettiArray[0].SetActive(true);
        confettiArray[1].SetActive(true);
        confettiArray[2].SetActive(true);
        confettiArray[3].SetActive(true);
    }

    public void WinPanel()
    {
        nothanks_Coin.text = ((int)(Coin.collectedCoin * RangeBar.multiplier)).ToString();
        multiple_Coin.text = ((int)((Coin.collectedCoin * RangeBar.multiplier)*5)).ToString();
        winPanel_BlackPanel.SetActive(true);
        winPanel.SetActive(true);
        Invoke("Nothanks_Button", 1f);
    }

    void Nothanks_Button()
    {
        NoThanks_Button.SetActive(true);
    }
}
