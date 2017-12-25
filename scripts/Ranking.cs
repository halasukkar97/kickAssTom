using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    private GameManagement m_GameManagement;
    private Text m_TextUserName, m_TextUserScore;
    private Text[] m_TextRankingNames = new Text[5];
    private Text[] m_TextRankingScores = new Text[5];

    public int buttonID;

	// Use this for initialization
	void Start () {

        //textUserName = new GameObject().GetComponent<Text>();
        m_TextUserName = GameObject.Find("UserName").GetComponent<Text>();

        //textUserScore = new GameObject().GetComponent<Text>();
        m_TextUserScore = GameObject.Find("UserScore").GetComponent<Text>();

        for(int i=0; i< m_TextRankingNames.Length; i++)
        {
            m_TextRankingNames[i] = GameObject.Find("RankingNames"+i).GetComponent<Text>();
        }

        for (int i = 0; i < m_TextRankingScores.Length; i++)
        {
            m_TextRankingScores[i] = GameObject.Find("RankingScores"+i).GetComponent<Text>();
        }

        m_GameManagement = new GameManagement();
        m_TextUserName.text = m_GameManagement.GetUserName();
        m_TextUserScore.text = m_GameManagement.GetSingleUserScore(1);
	}

    public void OnBackBtnClick()
    {
        //Goto Main Menu
        m_GameManagement.LoadScene(3, false);
    }

    public void OnStageBtnClick()
    {
        //GameObject.Find("Stage" + buttonID).GetComponent<Renderer>().material.color = Color.red;
        m_TextUserScore.text = m_GameManagement.GetSingleUserScore(buttonID + 1);

        string[] s = m_GameManagement.GetBestUserNames(buttonID + 1, 5).Split('\t');
        for(int i=0; i< m_TextRankingNames.Length; i++)
        {
            m_TextRankingNames[i].text = s[i];
        }

        s = m_GameManagement.GetBestUserScores(buttonID + 1, 5).Split('\t');
        for (int i = 0; i < m_TextRankingScores.Length; i++)
        {
            m_TextRankingScores[i].text = s[i];
        }
    }
}
