using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RangeBar : MonoBehaviour
{
    Image rangeBarIn;

    public GameObject Camera;

    public GameObject weaponOBJ;

    public GameObject RangeBarIMG;
    public GameObject RangeBarButton;

    public GameObject cube;
    public GameObject karakter;
    public GameObject[] targetCubes;
    public GameObject TargetParent;

    public GameObject failPanel;
    public GameObject CoinCountText;

    public static float multiplier;

    ThrowSimulation throwSimulation;
    float time;
    bool timeBool = false;
    public static bool afterKick_Start;
    public GameObject target;

    public AudioSource kickSource;
    public AudioClip kickClip;

    void Start()
    {
        weaponOBJ.SetActive(false);

        multiplier = 0;
        afterKick_Start = false;
        timeBool = false;
        throwSimulation = GameObject.FindObjectOfType<ThrowSimulation>();
        rangeBarIn = GetComponent<Image>();
        StartCoroutine("RangeBarFill");
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= 3 && !timeBool)
        {
            StopCoroutine("RangeBarFill");
            timeBool = true;
            StopAndRoll.isRotate = true;
            RangeBarButton.SetActive(false);
            RangeBarIMG.GetComponent<Image>().enabled = false;
            RangeBarIMG.transform.GetChild(0).GetComponent<Image>().enabled = false;

            if(rangeBarIn.fillAmount >= .2f) //&& afterKick_Start)
                karakter.GetComponent<Animator>().SetTrigger("kick");
            else if(rangeBarIn.fillAmount < .2f)
                cube.GetComponent<Animator>().SetTrigger("kick");

            Invoke(nameof(KickSound), .7f);
            Invoke("After_Kick", .85f);
        }

    }

    void KickSound()
    {
        kickSource.PlayOneShot(kickClip);
    }

    private void LateUpdate()
    {
        if (afterKick_Start)
        {
            Camera.transform.position = new Vector3(0.49f, 8.25f, cube.transform.position.z - 13.51f);
        }
    }

    IEnumerator RangeBarFill() //rangeBar ın .1 saniyede azalmasini saglar.
    {
        while(rangeBarIn.fillAmount >= 0)
        {
            yield return new WaitForSecondsRealtime(.1f);
            rangeBarIn.fillAmount -= .01f;
        }
    }

    public void After_Kick() // range_bar ın aralıklarına gore zombie bossun gidicegi kareleri hesaplar.
    {
        RangeBarButton.SetActive(false);

        //cube.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (rangeBarIn.fillAmount >= .9f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 3).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 3).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .8f && rangeBarIn.fillAmount < .9f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 4).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 4).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .7f && rangeBarIn.fillAmount < .8f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 5).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 5).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .6f && rangeBarIn.fillAmount < .7f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 6).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 6).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .5f && rangeBarIn.fillAmount < .6f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 7).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 7).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .4f && rangeBarIn.fillAmount < .5f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 8).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 8).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .3f && rangeBarIn.fillAmount < .4f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 9).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 9).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= .2f && rangeBarIn.fillAmount < .3f)
        {
            afterKick_Start = true;
            cube.GetComponent<Animator>().SetTrigger("fly_start");
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 10).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            Invoke("Fly_Finish", .75f);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 10).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        else if (rangeBarIn.fillAmount >= 0f && rangeBarIn.fillAmount < .2f)
        {
            karakter.GetComponent<Animator>().SetTrigger("fly_start");
            karakter.transform.DOMove(new Vector3(0, 0, 0),2);
            Invoke("Karakter_FlyFinish", 1.75f);
            Invoke("Fail_Panel", 2.5f);
            //cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 11).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            //multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 11).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }
        /*else if (rangeBarIn.fillAmount >= .0f && rangeBarIn.fillAmount < .1f)
        {
            cube.transform.DOMove(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 12).transform.position, 1).OnComplete(() => StopAndRoll.isRotate = false);
            multiplier = float.Parse(TargetParent.transform.GetChild((int)((PlayerPrefs.GetFloat("firstX") / .2f)) - 12).transform.GetChild(1).GetComponent<TextMesh>().text.Substring(2));
        }*/
    }

    void Fly_Finish() // Zombie bossun yere dusme animasyonu
    {
        cube.GetComponent<Animator>().SetTrigger("fly_finish");
    }

    void Karakter_FlyFinish() // karakterin yere dusme animasyonu
    {
        karakter.GetComponent<Animator>().SetTrigger("fly_finish");
    }

    void Fail_Panel()
    {
        CoinCountText.SetActive(false);
        failPanel.SetActive(true);
    }

    public void IncreaseRangeBarFill() //ekrana tikladikca rangeBarın .5 artmasini saglar.
    {
        rangeBarIn.fillAmount += .05f;
    }

}
