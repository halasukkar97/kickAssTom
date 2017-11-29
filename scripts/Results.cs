using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Results : MonoBehaviour {
    private GameState m_gamestate = new GameState();
    public Text Message;


    // Use this for initialization
    void Start () {

        if (gamewatch.lost == true)
        {
            Message.text = "You Lost The Round but You can Give it Another Try";
            gamewatch.lost = false;
        }
        else
        {
            Message.text = "you won , you have now " + m_gamestate.GetMoney().ToString() + " Gold in the Bank, want to try one more time ? ";
        }
    }
	
}
