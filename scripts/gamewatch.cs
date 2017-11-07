using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamewatch : MonoBehaviour {

    public Text gameTimeText;
    float gameTimer = 120f;
    bool gameStop=false;


	// Update is called once per frame
	void Update () {
        if(!gameStop)
        {

            gameTimer -= Time.deltaTime;

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;

            string timerstring = string.Format("{0:00}:{1:00}", minutes, seconds);

            gameTimeText.text = timerstring;

            if (gameTimer <= 0f)
            {
                Application.LoadLevel(2);
            }

        }
    
    }


    public void PauseStopTime()
    {
        gameStop = true;

    }

    public void ResumePlayTime()
    {
        gameStop = false;

    }
}
