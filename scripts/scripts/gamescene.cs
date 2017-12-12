using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gamescene : MonoBehaviour
{

    GameState m_gamestate = new GameState();
    public Pause _pause;
    beginn _beginn = new beginn();

    public Text boms;
    public Text shild;
    public Text potions;


    void Start()
    {

        _pause._panel.SetActive(false);
        boms.text = m_gamestate.GetBombs().ToString();
        shild.text = m_gamestate.GetShields().ToString();
        potions.text = m_gamestate.GetPotions().ToString();
    }

    public void Bombs()
    {
        if (m_gamestate.GetBombs() <= 0)
        {
            boms.text = "0";
        }
        else
        {
            m_gamestate.AddBombs(-1);
            boms.text = m_gamestate.GetBombs().ToString();
        }


        _beginn.DeleteAllEnemies();
        
    }
    public void Shilds()
    {
        if (m_gamestate.GetShields() <= 0)
        {
            shild.text = "0";
        }
        else
        {
            m_gamestate.AddShields(-1);
            shild.text = m_gamestate.GetShields().ToString();
        }

      
    }

    public void Postions()
    {
        if (m_gamestate.GetPotions() <= 0)
        {
            potions.text = "0";
        }
        else
        {
            m_gamestate.AddPotions(-1);
            m_gamestate.AddHearts(+3);
            potions.text = m_gamestate.GetPotions().ToString();
        }

      

    }


}
