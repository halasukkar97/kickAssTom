using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour{

    GameState m_gamestate = new GameState();

	public void LogIn()
    {
        //load LogIn screen
        m_gamestate.LoadScene(1, false);
    }

    public void NewUser()
    {
        //load New User screen
        m_gamestate.LoadScene(2, false);
    }

    public void EndGame()
    {
        //end application
        Application.Quit();
    }
}
