using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Ga_Inıt : MonoBehaviour
{
    private void Awake()
    {
        GameAnalytics.Initialize();
    }

    public void LevelComplete(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
    }

    public void LevelComplete16(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "41."+level.ToString());
    }

    public void LevelFail(int yuzde)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, yuzde.ToString());
    }

    public void LevelAnaliz(int day, int bolum)
    {
        GameAnalytics.NewDesignEvent("levelexit:day", day);
        GameAnalytics.NewDesignEvent("levelexit:day:bolum", bolum);
    }

}
