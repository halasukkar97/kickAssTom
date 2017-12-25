using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour {

    private GameManagement m_GameManagement = new GameManagement();
    private BannerAdvertisement m_BannerAdvertisement;
    private MainMenu m_MainMenu;
    public void Start()
    {
        m_BannerAdvertisement = new BannerAdvertisement();
        m_MainMenu = new MainMenu();
    }

    //when button is pressed to try the level again
    public void TryAgain()
    {
        

        switch(m_MainMenu.GameIndex())
        {
            case 1:
                m_BannerAdvertisement.RemoveBanner();
                m_GameManagement.LoadScene(6, true);
                break;
            case 2:
                m_BannerAdvertisement.RemoveBanner();
                m_GameManagement.LoadScene(7, true);
                break;
            case 3:
                m_BannerAdvertisement.RemoveBanner();
                m_GameManagement.LoadScene(8, true);
             break;
            case 4:
                m_BannerAdvertisement.RemoveBanner();
                m_GameManagement.LoadScene(9, true);
             break;
            case 5:
                m_BannerAdvertisement.RemoveBanner();
                m_GameManagement.LoadScene(10, true);
              break;
        }

    }

    public void BackToStartScene()
    {

        m_GameManagement.LoadScene(0, false);
    }

    //when button is pressed to go back to main menu if the level is finished
    public void BackToMainMenuScene()
    {
        m_BannerAdvertisement.ShowBanner();
        m_GameManagement.LoadScene(3, true);
    }

    //when button is pressed to go back to stage select
    public void BackToStageSelect()
    {
        m_GameManagement.LoadScene(4, true);
        
    }

}
