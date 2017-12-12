using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

public class videoAds : MonoBehaviour {

    private GameState m_gamestate = new GameState();
    public Button videoAd;
 
    public void ShowRewardedAd()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //add gold and disable the button
                m_gamestate.AddMoney(500);
                videoAd.interactable = false;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was Skipped.");
                videoAd.interactable = false;
                break;
            case ShowResult.Failed:
                Debug.Log("The ad was faild.");
                break;

        }
    }
}
