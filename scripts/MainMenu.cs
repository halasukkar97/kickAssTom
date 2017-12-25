using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class MainMenu : MonoBehaviour
{
    private GameManagement m_GameManagement = new GameManagement();
    public Text m_UserName;
    public Text m_Money;
    private static int GAME_INDEX;
    private BannerAdvertisement m_BannerAdvertisement;

    public void Start()
    {
        m_BannerAdvertisement = new BannerAdvertisement();
        m_BannerAdvertisement.ShowBanner();
        m_UserName.text = m_GameManagement.GetUserName(); //start with showing the user name
        m_Money.text = m_GameManagement.GetMoney().ToString(); // and showing the user how much mony he has
    }

    private void Update()
    {
        m_Money.text = m_GameManagement.GetMoney().ToString(); //keep updating the money text so the money amount change after watching the rewarded video ad
    }

    public int GameIndex()
    {
        return GAME_INDEX;
    }

    public void SetIndex(int Index)
    {
        GAME_INDEX = Index; // set index to know wich level we are in 
    }

    public void GoToStageSelect() //if stage select button is pressed
    {
        m_BannerAdvertisement.ShowBanner();
        m_GameManagement.LoadScene(4, true); // got to scene stage select
    }

    public void GoToShop() //if the shop button is pressed 
    {
        m_BannerAdvertisement.ShowBanner(); // show adds banner
        m_GameManagement.LoadScene(13, false); //open scene 13
    }

    public void LogOut() //if log out button is pressed
    {
        m_GameManagement.LoadScene(0, true); //open scene 0
    }


    public void Ranking() //if ranking button is pressed
    {
        m_BannerAdvertisement.ShowBanner();
        m_GameManagement.LoadScene(12, true); // open scene 12
    }




}