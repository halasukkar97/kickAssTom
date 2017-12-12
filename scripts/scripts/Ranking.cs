using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    private GameState m_gamestate;
    private Text textUserName, textUserScore, textRankingNames, textRankingScores;

    public int buttonID;

	// Use this for initialization
	void Start () {

        //textUserName = new GameObject().GetComponent<Text>();
        textUserName = GameObject.Find("UserName").GetComponent<Text>();

        //textUserScore = new GameObject().GetComponent<Text>();
        textUserScore = GameObject.Find("UserScore").GetComponent<Text>();

        //textRankingNames = new GameObject().GetComponent<Text>();
        textRankingNames = GameObject.Find("RankingNames").GetComponent<Text>();

        //textRankingScores = new GameObject().GetComponent<Text>();
        textRankingScores = GameObject.Find("RankingScores").GetComponent<Text>();

        m_gamestate = new GameState();
        textUserName.text = m_gamestate.GetUserName();
        textUserScore.text = m_gamestate.GetSingleUserScore(1);
	}

    public void OnBackBtnClick()
    {
        //Goto Main Menu
        m_gamestate.LoadScene(1, false);
    }

    public void OnStageBtnClick()
    {

        textUserScore.text = m_gamestate.GetSingleUserScore(buttonID + 1);
        textRankingNames.text = m_gamestate.GetBestUserNames(buttonID + 1, 5);
        textRankingScores.text = m_gamestate.GetBestUserScores(buttonID + 1, 5);
    }
}
