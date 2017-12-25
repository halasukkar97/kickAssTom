using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement
{

    private DataBaseInteraction m_DataBase = new DataBaseInteraction();

    private static int USER_ID, MONEY, LEVEL_PROGRESS, HEARTS, BOMBS, SHIELDS, POTIONS;
    private static string USERNAME, PASSWORD;

    /// <summary>
    /// Updates the user data in the database if updateUser is set to true
    /// and loads the scene with the given sceneIndex.
    /// </summary>
    /// <param name="SceneIndex"></param>
    /// <param name="UpdateUser"></param>
    public void LoadScene(int SceneIndex, bool UpdateUser)
    {
        if (UpdateUser == true)
            m_DataBase.updateUser(USER_ID, USERNAME, PASSWORD, MONEY, LEVEL_PROGRESS, HEARTS, BOMBS, SHIELDS, POTIONS);

        
        SceneManager.LoadScene(SceneIndex);
        Debug.Log("Money: " + MONEY + " UserID: " + USER_ID);
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
        string[] names = m_DataBase.GetAttributeOfAllUsers("Name").Split('\t');
        string[] passwords = m_DataBase.GetAttributeOfAllUsers("Password").Split('\t');

        

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
                USERNAME = Name;
                USER_ID = i+1;
                PASSWORD = passwords[i];

                Debug.Log("UserName: " + USERNAME + " | Password: " + PASSWORD);
            }
        }

        Debug.Log(USER_ID);

        if(Password.Equals(PASSWORD))
        {
            string[] userData = m_DataBase.GetUserData(USER_ID).Split('\t');

            foreach(string s in userData)
            {
                Debug.Log("UserData: " + s);
            }
            MONEY = System.Int32.Parse(userData[3]);
            LEVEL_PROGRESS = System.Int32.Parse(userData[4]);
            HEARTS = System.Int32.Parse(userData[5]);
            BOMBS = System.Int32.Parse(userData[6]);
            SHIELDS = System.Int32.Parse(userData[7]);
            POTIONS = System.Int32.Parse(userData[8]);

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
        string s = m_DataBase.GetSingleUserScore(stage, USER_ID);

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
        string s = m_DataBase.GetBestUserScores(Stage, Amount);
        if (s != null)
            return s;
        else
            return "The best user scores could not be recieved from the database!";
    }

    public string GetBestUserNames(int Stage, int Amount)
    {
        string s = m_DataBase.GetBestUserNames(Stage, Amount);
        if (s != null)
            return s;
        else
            return "The names of the best users could not be recieved!";
    }

    public bool NewUser(string Name, string Password)
    {
        USER_ID = m_DataBase.AddUser(Name, Password);

        if (USER_ID == -1)
        {
            USER_ID = 0; // reset m_userID
            return false; // Adding a user failed
        }

        USERNAME = Name;
        PASSWORD = Password;
        MONEY = 0;
        LEVEL_PROGRESS = 0;
        HEARTS = 3;
        BOMBS = 0;
        SHIELDS = 0;
        POTIONS = 0;
        

        return true;
    }

    public string GetAttribute(string attribute)
    {
        string s = m_DataBase.GetAttributeOfAllUsers(attribute);
        if (s != null)
            return s;
        else
            return "The attribute of all users could not be recieved!";
    }

    //_____________________________________________________GETTER FUNCTIONS
    public int GetUserID() { return USER_ID; }

    public int GetMoney() { return MONEY; }
    public int GetLevelProgress() { return LEVEL_PROGRESS; }
    public int GetHearts(){return HEARTS;}
    public int GetBombs(){return BOMBS;}
    public int GetShields(){return SHIELDS;}
    public int GetPotions() { return POTIONS; }
    public string GetUserName(){return USERNAME;}
    public string GetPassword(){return PASSWORD;}

    //_____________________________________________________SETTER FUNCTIONS

    public void SetUserUD(uint value) { USER_ID = (int)value; }
    public void SetUserName(string name) { USERNAME = name; }
    public void AddMoney(int amount) { MONEY += amount; Debug.Log("Money: "+MONEY + " UserID: "+USER_ID); }
    public void SetLevelProgress(uint value) { LEVEL_PROGRESS = (int)value; }
    public void SetHearts(int value) { HEARTS = value; }
    public void AddHearts(int amount) { HEARTS += amount; }
    public void AddBombs(int amount) { BOMBS += amount; }
    public void AddShields(int amount) { SHIELDS += amount; }
    public void AddPotions(int amount) { POTIONS += amount; }
    public void SetPassword(string password) { PASSWORD = password; }


}
