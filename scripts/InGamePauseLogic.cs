using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePauseLogic : MonoBehaviour {

    private GameManagement m_GameManagement = new GameManagement();


    public UpAttack m_UpButton;
    public DownAttack m_DownButton;
    public MiddleAttack m_MiddleButton;
    public InGameTimer m__Gamewatch;
    public EnemySpawn m_EnemySpawn;
    public GameObject m_Panel;
    private EnemyMovement m_Enemy;
    private BannerAdvertisement m_BannerAdvertisement;

    public void Start()
    {
        m_Enemy = new EnemyMovement(); 
        m_BannerAdvertisement = new BannerAdvertisement();
    }
    public void Pausepress() //if paused is pressed
    {
        //set the buttons to paused and disable them
        m_UpButton.PauseDisable();
        m_MiddleButton.PauseDisable();
        m_DownButton.PauseDisable();

        //stop the game watch and timer
        m__Gamewatch.PauseStopTime();

        //stop creating new ai
        m_EnemySpawn.PauseGame();

        //bring the panel
        m_Panel.SetActive(true);

        //stop the ai from moving
        m_Enemy.PauseGame();

    }

    public void Resume() //if the resume button is pressed
    {
        //hide the panel
        m_Panel.SetActive(false);

        //active the buttons
        m_UpButton.Resume();
        m_MiddleButton.Resume();
        m_DownButton.Resume();

        //resume the timer 
        m__Gamewatch.ResumePlayTime();

        //start creating new AI
        m_EnemySpawn.ResumeGame();

        //resume game
        m_Enemy.ResumeGame();
    }

    public void MainMenu() //if main menu is pressed
    {
        Resume(); //call resume function
        m_BannerAdvertisement.ShowBanner(); //show the banner
        m_GameManagement.LoadScene(3, false); //open scene main menu

    }

}
