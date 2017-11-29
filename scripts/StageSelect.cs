using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {

    private GameState m_gamestate = new GameState();
    private AddMob _addmob;
    private MainMenu _mainMenu;

    public void Start()
    {
        _addmob = new AddMob();
        _mainMenu = new MainMenu();
    }

    public enum ButtonName
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
        instructions
    }

    public ButtonName btnName;

	public void OnClick()
    {
        switch(btnName)
        {
            case ButtonName.stage1:
                _addmob.RemoveBanner();
                _mainMenu.SetIndex(1);
                m_gamestate.LoadScene(2, false);

                break;
            case ButtonName.stage2:
                _addmob.RemoveBanner();
                _mainMenu.SetIndex(2);
                m_gamestate.LoadScene(9, false);
                
                break;
            case ButtonName.stage3:
                _addmob.RemoveBanner();
                _mainMenu.SetIndex(3);
                m_gamestate.LoadScene(3, false);

                break;
            case ButtonName.stage4:
                _addmob.RemoveBanner();
                _mainMenu.SetIndex(4);
                m_gamestate.LoadScene(10, false);

                break;
            case ButtonName.stage5:
                _addmob.RemoveBanner();
                _mainMenu.SetIndex(5);
                m_gamestate.LoadScene(11, false);

                break;
            case ButtonName.instructions:
                m_gamestate.LoadScene(8, false);
                break;
        }
    }
}
