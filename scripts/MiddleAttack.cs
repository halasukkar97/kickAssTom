﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiddleAttack : MonoBehaviour
{

    public PlayerLogic m_Player;

    public ScoreEvaluation m_GameScore;

    public void Press() //if button is pressed
    {
        if (m_Player.m_EnemyMiddleIsIn == true) //if middle attack is true
        {
            WrongPress();//call this function to make sure this is the right ai
            Destroy(m_Player.m_EnemyMiddle);//kill the enemey
            m_GameScore.m_CurrentScore += (10 + m_GameScore.GetBonusPoints()); //add the points and the bounes points chain  to the score
            m_Player.m_EnemyMiddleIsIn = false;//reset the bool to false

            m_GameScore.Currentscore(); //update the new score
            m_GameScore.AddToBonusPoints(1);//add bounes point to the bounes point chain

        }
    }


    public void WrongPress()//this function will check wich AI came 
    {
        if (m_Player.m_EnemyUpIsin == true || m_Player.m_EnemyDownIsIn == true)// if the wrong button is pressed
        {
            m_GameScore.ResetBonusPoints();//restart the bounes point chain
        }

    }


    public void PauseDisable() //in case the pouse button is pressed
    {
        this.GetComponent<Button>().interactable = false; //disable the buttons
    }

    public void Resume()//if the resume button is pressed
    {
        this.GetComponent<Button>().interactable = true; //activate the buttons
    }


}
