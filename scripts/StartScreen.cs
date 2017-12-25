using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour{

    GameManagement m_GameManagement = new GameManagement();
    private BannerAdvertisement m_BannerAdvertisement;

    public void LogIn()
    {
        //load LogIn screen
        m_GameManagement.LoadScene(1, false);
    }

    public void NewUser()
    {
        //load New User screen
        m_GameManagement.LoadScene(2, false);
    }

    public void EndGame()
    {
        //end application
        Application.Quit();
    }
}
