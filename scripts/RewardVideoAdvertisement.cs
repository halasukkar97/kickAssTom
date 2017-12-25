using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

public class RewardVideoAdvertisement : MonoBehaviour {

    private GameManagement m_GameManagement = new GameManagement();
    public Button m_WatchVideoAdButton;
 
    public void ShowRewardedAd() //if the show video button is pressed 
    {
        if(Advertisement.IsReady("rewardedVideo")) //and if the video is ready 
        {
            var options = new ShowOptions { resultCallback = _HandleShowResult };
            Advertisement.Show("rewardedVideo", options);//show the video
        }
    }

  
    private void _HandleShowResult(ShowResult Result)
    {
        switch (Result)
        {
            case ShowResult.Finished://if the user watched the whole video
                Debug.Log("The ad was successfully shown.");
                m_GameManagement.AddMoney(500); //give the player 500 points and gold
                Debug.Log("AddMoney" + m_GameManagement.GetMoney());
                m_WatchVideoAdButton.interactable = false;//disable the video add button
                break;
            case ShowResult.Skipped://if the user skipped the video
                Debug.Log("The ad was Skipped.");
                m_WatchVideoAdButton.interactable = false;//set the button to disable mood
                break;
            case ShowResult.Failed://if the video failed to open dont do anything
                Debug.Log("The ad was faild.");
                break;

        }
    }
}
