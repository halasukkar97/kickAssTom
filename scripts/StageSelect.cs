using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {

    private GameManagement m_GameManagement = new GameManagement();
    private BannerAdvertisement m_BannerAdvertisement;
    private MainMenu m_MainMenu;

    public void Start()
    {
        m_BannerAdvertisement = new BannerAdvertisement();
        m_BannerAdvertisement.ShowBanner();
        m_MainMenu = new MainMenu();
    }

    public enum ButtonName
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
        instructions,
        BackToMainMenu
    }

    public ButtonName m_ButtonName;

	public void OnClick()
    {
        switch(m_ButtonName)
        {
            case ButtonName.stage1:
                m_BannerAdvertisement.RemoveBanner();
                m_MainMenu.SetIndex(1);
                m_GameManagement.LoadScene(6, false);

                break;
            case ButtonName.stage2:
                m_BannerAdvertisement.RemoveBanner();
                m_MainMenu.SetIndex(2);
                m_GameManagement.LoadScene(7, false);
                
                break;
            case ButtonName.stage3:
                m_BannerAdvertisement.RemoveBanner();
                m_MainMenu.SetIndex(3);
                m_GameManagement.LoadScene(8, false);

                break;
            case ButtonName.stage4:
                m_BannerAdvertisement.RemoveBanner();
                m_MainMenu.SetIndex(4);
                m_GameManagement.LoadScene(9, false);

                break;
            case ButtonName.stage5:
                m_BannerAdvertisement.RemoveBanner();
                m_MainMenu.SetIndex(5);
                m_GameManagement.LoadScene(10, false);

                break;
            case ButtonName.instructions:
                m_BannerAdvertisement.ShowBanner();
                m_GameManagement.LoadScene(5, false);
                break;
            case ButtonName.BackToMainMenu:
                m_BannerAdvertisement.ShowBanner();
                m_GameManagement.LoadScene(3, false);
                break;
        }
    }
}
