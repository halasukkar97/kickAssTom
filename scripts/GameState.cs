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
        if (m_db.AddUser(Name, Password) == false)
            return false;

        return true;
    }

    public string GetAttribute(string attribute)
    {
        return m_db.GetAttributeOfAllUsers(attribute);
    }
}
