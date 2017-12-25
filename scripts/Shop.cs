using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    private GameManagement m_GameManagement;
    private Text m_Name;
    private Text m_Money;
    private Text m_TextLimit;

    public int m_ButtonID;
    public int m_Cost;

    private static int HEARTS_MAX = 10;
    private static int BOMBS_MAX = 4;
    private static int SHIELDS_MAX = 5;
    private static int POTIONS_MAX = 3;

	// Use this for initialization
	void Start () {
        m_GameManagement = new GameManagement();
        m_Name = GameObject.Find("Name").GetComponent<Text>();
        m_Money = GameObject.Find("Money").GetComponent<Text>();
        m_TextLimit = GameObject.Find("TextLimit").GetComponent<Text>();

        m_Name.text = m_GameManagement.GetUserName();
        m_Money.text = m_GameManagement.GetMoney().ToString();
        m_TextLimit.text = "you have " + m_GameManagement.GetHearts().ToString() + " Hearts out of 10, and " + m_GameManagement.GetBombs().ToString() + " Bombs out of  4, and " + m_GameManagement.GetPotions().ToString() + " Potions out of 3, and " + m_GameManagement.GetShields().ToString() + " Shilds out of 5 ";

    }

    public void Update()
    {
        m_TextLimit.text = "you have " + m_GameManagement.GetHearts().ToString() + " Hearts out of 10, and " + m_GameManagement.GetBombs().ToString() + " Bombs out of  4, and " + m_GameManagement.GetPotions().ToString() + " Potions out of 3, and " + m_GameManagement.GetShields().ToString() + " Shilds out of 5 ";
    }

    public void OnButtonClick()
    {
        if(m_GameManagement.GetMoney() >= m_Cost)
        {
            switch (m_ButtonID)
            {
                case 0:
                    if(m_GameManagement.GetHearts()<HEARTS_MAX)
                    {
                        m_GameManagement.AddHearts(1);
                        m_GameManagement.AddMoney(-m_Cost);
                    }
                    break;
                case 1:
                    if (m_GameManagement.GetBombs() < BOMBS_MAX)
                    {
                        m_GameManagement.AddBombs(1);
                        m_GameManagement.AddMoney(-m_Cost);
                    }
                    break;
                case 2:
                    if (m_GameManagement.GetPotions() < POTIONS_MAX)
                    {
                        m_GameManagement.AddPotions(1);
                        m_GameManagement.AddMoney(-m_Cost);
                    }
                    break;
                case 3:
                    if (m_GameManagement.GetShields() < SHIELDS_MAX)
                    {
                        m_GameManagement.AddShields(1);
                        m_GameManagement.AddMoney(-m_Cost);
                    }
                    break;
            }

            m_Money.text = m_GameManagement.GetMoney().ToString();
        }
        
    }

    public void BackToMainMenu()
    {
        m_GameManagement.LoadScene(3, true);
    }

	
	
}
