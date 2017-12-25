using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreEvaluation : MonoBehaviour
{
    public Text m_GameScore;
    public Text m_Points;
    public int m_CurrentScore;
    private int m_BonusPoints = 0;
    public int m_MaxPoints;
    private int timerCounter = 0;
    // Use this for initialization


    void Start()
    {
        m_CurrentScore = 0;//set the score to 0
        m_Points.text = ""; 

    }

    private void Update()
    {
        if (timerCounter >= 120)//if the game timer is more then 120
        {
            timerCounter = 0;//set the timer to 0
            m_Points.text = "";
        }

        timerCounter++;//keep the timer going on 
        

    }

    public void Currentscore()
    {
        m_GameScore.text = m_CurrentScore.ToString() + "/" + m_MaxPoints;//show in a text how much points the user made and how much points he should get


        m_Points.text = "" + (m_BonusPoints + 10);//show bouns points chain in a text 
      
    }

    public void ResetBonusPoints()
    {
        m_BonusPoints = 0; //in case of pressing the wrong button reset the bounes points to 0
    }

    public void AddToBonusPoints(int Value)
    {
        m_BonusPoints += Value; // add the value to the bounes points
    }

    public int GetBonusPoints()
    {
        return m_BonusPoints;
    }

   




}
