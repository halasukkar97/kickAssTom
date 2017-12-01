using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    private GameState m_gameState;
    private Text textName;
    private Text textMoney;
    
    public int buttonID;
    public int cost;

	// Use this for initialization
	void Start () {
        m_gameState = new GameState();
        textName = GameObject.Find("Name").GetComponent<Text>();
        textMoney = GameObject.Find("Money").GetComponent<Text>();

        textName.text = m_gameState.GetUserName();
        textMoney.text = m_gameState.GetMoney().ToString();
	}

    public void OnButtonClick()
    {
        if(m_gameState.GetMoney() >= cost)
        {
            switch (buttonID)
            {
                case 0:
                    m_gameState.AddHearts(1);
                    break;
                case 1:
                    m_gameState.AddBombs(1);
                    break;
                case 2:
                    m_gameState.AddPotions(1);
                    break;
                case 4:
                    m_gameState.AddShields(1);
                    break;
            }

            textMoney.text = m_gameState.GetMoney().ToString();
        }
        
    }

    public void BackToMainMenu()
    {
        m_gameState.LoadScene(1, true);
    }

	
	
}
