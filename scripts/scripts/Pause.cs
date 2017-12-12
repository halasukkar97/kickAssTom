using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    GameState m_gamestate = new GameState();


    public up _up;
    public down _down;
    public middle _middle;
    public gamewatch _gamewatch;
    public beginn _beginn;
    public GameObject _panel;
    public AI _ai;
    private AdMob _addmob;

    public void Start()
    {
        _addmob = new AdMob();
    }
    public void Pausepress()
    {
        _up.PauseDisable();
        _middle.PauseDisable();
        _down.PauseDisable();
        _gamewatch.PauseStopTime();
        _beginn.PauseGame();
        _panel.SetActive(true);
        _ai.PauseGame();

    }

    public void Resume()
    {
        _panel.SetActive(false);
        _up.Resume();
        _middle.Resume();
        _down.Resume();
        _gamewatch.ResumePlayTime();
        _beginn.ResumeGame();
        _ai.ResumeGame();
    }

    public void MainMenu()
    {
        Resume();
        _addmob.AddBanner();
        m_gamestate.LoadScene(1, false);

    }

}
