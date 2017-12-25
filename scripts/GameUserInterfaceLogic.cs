using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameUserInterfaceLogic : MonoBehaviour
{

    GameManagement m_GameManagement = new GameManagement();
    public InGamePauseLogic m_Pause;
    EnemySpawn m_Beginn;
    public HitDetection m_Damage;

    public Text m_Bombs;
    public Text m_Shild;
    public Text m_Potions;

    public bool shildison = false;

    void Start()
    {
        m_Beginn = new EnemySpawn();
        //m_gamestate.AddPotions(10);
        m_Pause.m_Panel.SetActive(false); // when the game start hide the panel
        m_Bombs.text = m_GameManagement.GetBombs().ToString(); //show how many bombs the user has
        m_Shild.text = m_GameManagement.GetShields().ToString(); //show how many shilds the user has
        m_Potions.text = m_GameManagement.GetPotions().ToString(); //show how many poition the user has
    }

    private void Update()
    {
        m_Potions.text = m_GameManagement.GetPotions().ToString(); //update how many potions the user has
    }

    public void Bombs() //if the player presses bombs
    {
        if (m_GameManagement.GetBombs() <= 0) //if the user has 0 bombs
        {
            m_Bombs.text = "0"; //stop removing bombs and show that the user has 0 bombs
        }
        else //if not
        {
            m_GameManagement.AddBombs(-1); //remove one of the user bombs
            m_Bombs.text = m_GameManagement.GetBombs().ToString(); // show the new value of the user bombs 
            m_Beginn.DeleteAllEnemies(); //remove all AIs in the screen 
        }
        
    }
    public void Shilds() //if the shild button is pressed 
    {
        if(!m_Damage.GetShieldIsOn()) //if there is no shild 
        {
            if (m_GameManagement.GetShields() <= 0) //if the user has no shilds
            {
                m_Shild.text = "0"; // show 0 on how many shild the user has
            }
            else
            {
                m_GameManagement.AddShields(-1); //remove one of the user shilds
                m_Shild.text = m_GameManagement.GetShields().ToString(); // show the user the new amount of how many shilds thr uer has
                m_Damage.SetShieldIsOn(true); // set the shild on 
            }
        }
      
    }

    public void Potions() // if the button potions is pressed
    {
        Debug.Log("Potions");
        if (m_GameManagement.GetPotions() <= 0) //if the user has no potions
        {
            m_Potions.text = "0"; // show the user that he has no potions
        }
        else
        {
            m_GameManagement.AddPotions(-1); //remove on of the user potions
            m_Damage.AddHearts(3); // add 3 hearts to the user 
            m_Damage.DrawHearts(); //draw the 3 new hearts
            m_Potions.text = m_GameManagement.GetPotions().ToString(); // show the user how many hearts he has
        }
        
    }
    
}
