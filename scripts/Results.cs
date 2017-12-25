using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Results : MonoBehaviour {
    private GameManagement m_GameManagement = new GameManagement();
    public Text m_ResultText;


    // Use this for initialization
    void Start () {

        //if the user loses show him this text
        if (InGameTimer.LOST == true)
        {
            m_ResultText.text = "You Lost The Round but You can Give it Another Try";
            InGameTimer.LOST = false; //set the losing bool to false
        }
        else//if not show him this text
        {
            m_ResultText.text = "you won , you have now " + m_GameManagement.GetMoney().ToString() + " Gold in the Bank, want to try one more time ? ";
        }
    }
	
}
