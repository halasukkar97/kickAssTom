using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{

    private DBInteraction m_db = new DBInteraction();

    private static int m_userID, m_money, m_levelProgress, m_hearts, m_bombs, m_shields;
    private static string m_userName, m_password;

    /// <summary>
    /// Updates the user data in the database if updateUser is set to true
    /// and loads the scene with the given sceneIndex.
    /// </summary>
    /// <param name="SceneIndex"></param>
    /// <param name="UpdateUser"></param>
    public void LoadScene(int SceneIndex, bool UpdateUser)
    {
        if (UpdateUser == true)
            m_db.updateUser(m_userID, m_userName, m_password, m_money, m_levelProgress, m_hearts, m_bombs, m_shields);

        SceneManager.LoadScene(SceneIndex);
    }

    /// <summary>
    /// Loads user data when name and password are correct.
    /// Returns false when input incorrect.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public bool LoadUserData(string Name, string Password)
    {
        string[] names = m_db.GetAttributeOfAllUsers("Name").Split('\t');
        string[] passwords = m_db.GetAttributeOfAllUsers("Password").Split('\t');

        

        if (names == null || passwords == null)
            return false;

        foreach (string s in names)
        {
            Debug.Log(s);
        }
        foreach (string s in passwords)
        {
            Debug.Log(s);
        }

        Debug.Log("Names.Length: "+names.Length);
        Debug.Log("Passwords.Length: "+passwords.Length);
        for (int i=0; i<names.Length; i++)
        {
            if (names[i].Equals(Name))
            {
                m_userName = Name;
                m_userID = i+1;
                m_password = passwords[i];

                Debug.Log("UserName: " + m_userName + " | Password: " + m_password);
            }
        }

        Debug.Log(m_userID);

        if(Password.Equals(m_password))
        {
            string[] userData = m_db.GetUserData(m_userID).Split('\t');

            foreach(string s in userData)
            {
                Debug.Log("UserData: " + s);
            }
            m_money = System.Int32.Parse(userData[3]);
            m_levelProgress = System.Int32.Parse(userData[4]);
            m_hearts = System.Int32.Parse(userData[5]);
            m_bombs = System.Int32.Parse(userData[6]);
            m_shields = System.Int32.Parse(userData[7]);

            Debug.Log("Password correct");
        }
        else
        {
            Debug.Log("Password incorrect");
            return false;
        }

        return true;
            
    }

    public bool NewUser(string Name, string Password)
    {
        m_userID = m_db.AddUser(Name, Password);

        if (m_userID == -1)
        {
            m_userID = 0; // reset m_userID
            return false; // Adding a user failed
        }

        m_userName = Name;
        m_password = Password;
        m_money = 0;
        m_levelProgress = 0;
        m_hearts = 3;
        m_bombs = 0;
        m_shields = 0;
        

        return true;
    }

    public string GetAttribute(string attribute)
    {
        return m_db.GetAttributeOfAllUsers(attribute);
    }

    public int GetUserID()
    {
        return m_userID;
    }

    public int GetMoney()
    {
        return m_money;
    }

    public void AddMoney(int gold)
    {
        m_money += gold;
    }
    public int GetLevelProgress()
    {
        return m_levelProgress;
    }
    public int GetHearts()
    {
        return m_hearts;
    }
    public int GetBombs()
    {
        return m_bombs;
    }
    public int GetShields()
    {
        return m_shields;
    }
    public string GetUserName()
    {
        return m_userName;
    }

    public string GetPassword()
    {
        return m_password;
    }
}
