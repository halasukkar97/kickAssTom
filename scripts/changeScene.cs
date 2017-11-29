using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

    private GameState m_gamestate = new GameState();
    private AddMob _addmob;
    private MainMenu _mainMenu;
    public void Start()
    {
        _addmob = new AddMob();
        _mainMenu = new MainMenu();
    }

    //when button is pressed to try the level again
    public void TryAgain()
    {
        

        switch(_mainMenu.GameIndex())
        {
            case 1:
            _addmob.RemoveBanner();
            m_gamestate.LoadScene(2, true);
                break;
            case 2:
             _addmob.RemoveBanner();
            m_gamestate.LoadScene(9, true);
                break;
            case 3:
            _addmob.RemoveBanner();
             m_gamestate.LoadScene(3, true);
             break;
            case 4:
             _addmob.RemoveBanner();
             m_gamestate.LoadScene(10, true);
             break;
            case 5:
             _addmob.RemoveBanner();
             m_gamestate.LoadScene(11, true);
              break;
        }

    }

    public void BackToStartScene()
    {
      
        m_gamestate.LoadScene(0, false);
    }

    //when button is pressed to go back to main menu if the level is finished
    public void BackToMainMenuScene()
    {
        _addmob.AddBanner();
        m_gamestate.LoadScene(1, true);
    }

    //when button is pressed to go back to stage select
    public void BackToStageSelect()
    {
        m_gamestate.LoadScene(7, true);
        
    }

}
