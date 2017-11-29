using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gamescore : MonoBehaviour
{
    private GameState m_gamestate = new GameState();
    public Text gameScore;
    public Text addedPoints;
    public int currentScore;
    private int bonusPoints = 0;
    public int maxPoints;

 
    private int timerCounter = 0;
    // Use this for initialization
    void Start()
    {
        currentScore = 0;
        addedPoints.text = "";

    }

    private void Update()
    {
        if (timerCounter >= 120)
        {
            timerCounter = 0;
            addedPoints.text = "";
        }

        timerCounter++;
        

    }

    public void _currentscore()
    {
        gameScore.text = currentScore.ToString() + "/" + maxPoints;


        addedPoints.text = "" + (bonusPoints + 10);
      
    }

    public void ResetBonusPoints()
    {
        bonusPoints = 0;
    }

    public void AddToBonusPoints(int value)
    {
        bonusPoints += value;
    }

    public int GetBonusPoints()
    {
        return bonusPoints;
    }

   




}
