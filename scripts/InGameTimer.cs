using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InGameTimer : MonoBehaviour
{
    private GameManagement m_GameManagement = new GameManagement();   //game state skript
    public ScoreEvaluation m_Gamescore;                       // game score skript  
    public Text m_GameTimeText;                          //the watch text
    float m_GameTimer = 120.0f;                          //game timer
    bool m_GameStop = false;                             //bool to stop or play the game
    public static bool LOST = false;                   //static bool to know if the player lost or won

    // Update is called once per frame
    void Update()
    {
        if (!m_GameStop)      //if the game is running
        {

            m_GameTimer -= Time.deltaTime; // start the countdown

            int seconds = (int)(m_GameTimer % 60);  // set the sconds
            int minutes = (int)(m_GameTimer / 60) % 60; // set the minuts

            string timerstring = string.Format("{0:00}:{1:00}", minutes, seconds); // setting the watch on how will it look and where to start

            m_GameTimeText.text = timerstring; // give the watch to the text to show it on screen

            if (m_GameTimer <= 0.0f)  // if the time reaches 00:00 or less
            {
                if(m_Gamescore.m_CurrentScore >= m_Gamescore.m_MaxPoints) // and if the score the player have more then the wanted score
                {
                    m_GameManagement.AddMoney(m_Gamescore.m_CurrentScore);  //add money to his account
                    m_GameManagement.LoadScene(11, true);           // go to end scene
                }
                else  // if he didnt reach the score he needed to 
                {
                    m_GameManagement.LoadScene(11, true); // go to end scene
                    LOST = true; // activate the bool lost 
                }

            }
            

        }

    }

    // if the pause button pressed stop the game 
    public void PauseStopTime()
    {
        // set the bool to true to stop the game 
        m_GameStop = true;

    }

    // if the resume button was pressed resume the game
    public void ResumePlayTime()
    {
        // set the bool to false to play the game
        m_GameStop = false;

    }
}
