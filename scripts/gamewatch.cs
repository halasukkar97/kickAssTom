using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gamewatch : MonoBehaviour
{
    private GameState m_gamestate = new GameState();

    public gamescore _gamescore;

    public Text gameTimeText;
    float gameTimer = 120.0f;
    bool gameStop = false;
    public static bool lost = false;

    // Update is called once per frame
    void Update()
    {
        if (!gameStop)
        {

            gameTimer -= Time.deltaTime;

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;

            string timerstring = string.Format("{0:00}:{1:00}", minutes, seconds);

            gameTimeText.text = timerstring;

            if (gameTimer <= 0.0f)
            {
                if(_gamescore.currentScore >= _gamescore.maxPoints)
                {
                    m_gamestate.AddMoney(_gamescore.currentScore);
                    m_gamestate.LoadScene(4, true);
                }
                else
                {
                    m_gamestate.LoadScene(4, true);
                    lost = true;
                    // m_gamestate.GetMoney += _gamescore.money;
                }

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
