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

    private static int HEARTS_MAX = 10;
    private static int BOMBS_MAX = 4;
    private static int SHIELDS_MAX = 5;
    private static int POTIONS_MAX = 3;

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
                    if(m_gameState.GetHearts()<HEARTS_MAX)
                    {
                        m_gameState.AddHearts(1);
                        m_gameState.AddMoney(-cost);
                    }
                    break;
                case 1:
                    if (m_gameState.GetBombs() < BOMBS_MAX)
                    {
                        m_gameState.AddBombs(1);
                        m_gameState.AddMoney(-cost);
                    }
                    break;
                case 2:
                    if (m_gameState.GetPotions() < POTIONS_MAX)
                    {
                        m_gameState.AddPotions(1);
                        m_gameState.AddMoney(-cost);
                    }
                    break;
                case 3:
                    if (m_gameState.GetShields() < SHIELDS_MAX)
                    {
                        m_gameState.AddShields(1);
                        m_gameState.AddMoney(-cost);
                    }
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
