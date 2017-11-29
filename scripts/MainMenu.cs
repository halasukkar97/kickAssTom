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
       // m_gamestate.LoadScene(6, true);
    }

    public void LogOut()
    {
        m_gamestate.LoadScene(0, false);
    }

    public void Settings()
    {
       // m_gamestate.LoadScene(6, true);
    }

    public void Ranking()
    {
       // m_gamestate.LoadScene(6, true);
    }




}