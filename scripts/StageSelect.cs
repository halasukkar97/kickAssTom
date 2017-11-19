using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {

    private GameState m_gamestate = new GameState();

    public enum ButtonName
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5
    }

    public ButtonName btnName;

	public void OnClick()
    {
        switch(btnName)
        {
            case ButtonName.stage1:
                m_gamestate.LoadScene(0, false);
                break;
            case ButtonName.stage2:
                m_gamestate.LoadScene(0, false);
                break;
            case ButtonName.stage3:
                m_gamestate.LoadScene(0, false);
                break;
            case ButtonName.stage4:
                m_gamestate.LoadScene(0, false);
                break;
            case ButtonName.stage5:
                m_gamestate.LoadScene(0, false);
                break;
        }
    }
}
