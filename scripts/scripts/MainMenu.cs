using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class MainMenu : MonoBehaviour
{
    private GameState m_gamestate = new GameState();
    public Text UserName;
    public Text Money;
    private static int gameIndex;
    private AdMob _addmob;

    public void Start()
    {
        _addmob = new AdMob();
    }

    private void Update()
    {
        UserName.text = m_gamestate.GetUserName();
        Money.text = m_gamestate.GetMoney().ToString();
    }

    public int GameIndex()
    {
        return gameIndex;
    }

    public void SetIndex(int index)
    {
        gameIndex = index;
    }

    public void GoToStageSelect(int level)
    {
        m_gamestate.LoadScene(7, true);
    }

    public void GoToShop()
    {
        _addmob.AddBanner();
        m_gamestate.LoadScene(13, false);
    }

    public void LogOut()
    {
        m_gamestate.LoadScene(0, true);
    }

    public void Settings()
    {
       // m_gamestate.LoadScene(6, true);
    }

    public void Ranking()
    {
       m_gamestate.LoadScene(12, true);
    }




}