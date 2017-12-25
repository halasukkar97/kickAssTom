using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;

public class LogIn : MonoBehaviour {

    private InputField m_UserName;
    private InputField m_Password;

    Text m_TextLabel;

    private GameManagement m_GameManagement = new GameManagement();

    public void OnButtonClick()
    {

        m_UserName = GameObject.Find("UserName").GetComponent<InputField>();
        m_Password = GameObject.Find("Password").GetComponent<InputField>();

        m_TextLabel = GameObject.Find("Text").GetComponent<Text>();


        if (m_GameManagement.LoadUserData(m_UserName.text, m_Password.text) == true)
        {
            m_TextLabel.text = "LogIn successfull";

            //load main menu
            m_GameManagement.LoadScene(3,false);
        }
        else
        {
            m_TextLabel.text = "LogIn failed";
            m_UserName.text = "";
            m_Password.text = "";
        }
        

        
    }
}
