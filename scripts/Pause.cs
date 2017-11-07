﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public up _up;
    public down _down;
    public middle _middle;

    public gamewatch _gamewatch;
    public beginn _beginn;

    public GameObject _panel;

    public AI _ai;

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

    }
}
