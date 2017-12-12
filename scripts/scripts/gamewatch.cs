using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gamewatch : MonoBehaviour
{
    private GameState m_gamestate = new GameState();   //game state skript
    public gamescore _gamescore;                       // game score skript  
    public Text gameTimeText;                          //the watch text
    float gameTimer = 120.0f;                          //game timer
    bool gameStop = false;                             //bool to stop or play the game
    public static bool lost = false;                   //static bool to know if the player lost or won

    // Update is called once per frame
    void Update()
    {
        if (!gameStop)      //if the game is running
        {

            gameTimer -= Time.deltaTime; // start the countdown

            int seconds = (int)(gameTimer % 60);  // set the sconds
            int minutes = (int)(gameTimer / 60) % 60; // set the minuts

            string timerstring = string.Format("{0:00}:{1:00}", minutes, seconds); // setting the watch on how will it look and where to start

            gameTimeText.text = timerstring; // give the watch to the text to show it on screen

            if (gameTimer <= 0.0f)  // if the time reaches 00:00 or less
            {
                if(_gamescore.currentScore >= _gamescore.maxPoints) // and if the score the player have more then the wanted score
                {
                    m_gamestate.AddMoney(_gamescore.currentScore);  //add money to his account
                    m_gamestate.LoadScene(4, true);           // go to scene 4 
                }
                else  // if he didnt reach the score he needed to 
                {
                    m_gamestate.LoadScene(4, true); // go to scene 4
                    lost = true; // activate the bool lost 
                }

            }
            

        }

    }

    // if the pause button pressed stop the game 
    public void PauseStopTime()
    {
        // set the bool to true to stop the game 
        gameStop = true;

    }

    // if the resume button was pressed resume the game
    public void ResumePlayTime()
    {
        // set the bool to false to play the game
        gameStop = false;

    }
}
