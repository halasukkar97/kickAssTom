using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{

    private DBInteraction m_db = new DBInteraction();

    private static int m_userID, m_money, m_levelProgress, m_hearts, m_bombs, m_shields, m_potions;
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
            m_db.updateUser(m_userID, m_userName, m_password, m_money, m_levelProgress, m_hearts, m_bombs, m_shields, m_potions);

        
        SceneManager.LoadScene(SceneIndex);
        Debug.Log("Money: " + m_money + " UserID: " + m_userID);
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
            m_potions = System.Int32.Parse(userData[8]);

            Debug.Log("Password correct");
        }
        else
        {
            Debug.Log("Password incorrect");
            return false;
        }

        return true;
            
    }

    public string GetSingleUserScore(int stage)
    {
        string s = m_db.GetSingleUserScore(stage, m_userID);

        if (s != null)
            return s;
        else
            return "The single user score could not be recieved from the database!";
    }

    /// <summary>
    /// Returns string of the users with the best score on the given stage.
    /// The number of listed users is limited by amount.
    /// </summary>
    /// <param name="Stage"></param>
    /// <param name="Amount"></param>
    /// <returns></returns>
    public string GetBestUserScores(int Stage, int Amount)
    {
        string s = m_db.GetBestUserScores(Stage, Amount);
        if (s != null)
            return s;
        else
            return "The best user scores could not be recieved from the database!";
    }

    public string GetBestUserNames(int Stage, int Amount)
    {
        string s = m_db.GetBestUserNames(Stage, Amount);
        if (s != null)
            return s;
        else
            return "The names of the best users could not be recieved!";
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
        m_potions = 0;
        

        return true;
    }

    public string GetAttribute(string attribute)
    {
        string s =  m_db.GetAttributeOfAllUsers(attribute);
        if (s != null)
            return s;
        else
            return "The attribute of all users could not be recieved!";
    }

    //_____________________________________________________GETTER FUNCTIONS
    public int GetUserID() { return m_userID; }

    public int GetMoney() { return m_money; }
    public int GetLevelProgress() { return m_levelProgress; }
    public int GetHearts(){return m_hearts;}
    public int GetBombs(){return m_bombs;}
    public int GetShields(){return m_shields;}
    public int GetPotions() { return m_potions; }
    public string GetUserName(){return m_userName;}
    public string GetPassword(){return m_password;}

    //_____________________________________________________SETTER FUNCTIONS

    public void SetUserUD(uint value) { m_userID = (int)value; }
    public void SetUserName(string name) { m_userName = name; }
    public void AddMoney(int amount) { m_money += amount; Debug.Log("Money: "+m_money + " UserID: "+m_userID); }
    public void SetLevelProgress(uint value) { m_levelProgress = (int)value; }
    public void AddHearts(int amount) { m_hearts += amount; }
    public void AddBombs(int amount) { m_bombs += amount; }
    public void AddShields(int amount) { m_shields += amount; }
    public void AddPotions(int amount) { m_potions += amount; }
    public void SetPassword(string password) { m_password = password; }


}
