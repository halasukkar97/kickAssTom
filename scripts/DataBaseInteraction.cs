using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;

public class DataBaseInteraction {

    private string secretKey = "mySecretKey";
    private string startingEquipment = "&Money=0 &LevelProgress=0 &Hearts=3 &Bombs=0 &Shields=0 &Potions=0";

    private string ADD_USER_URL = "https://kickasstom.000webhostapp.com/AddUser.php?";
    private string NEW_USER_SCORE_URL = "https://kickasstom.000webhostapp.com/NewUserScore.php?";
    private string SHOW_ALL_USERS_URL = "https://kickasstom.000webhostapp.com/SelectAllUsers.php?";
    private string GET_ATTRIBUTE_OF_ALL_USERS_URL = "https://kickasstom.000webhostapp.com/GetAttribute.php?";
    private string UPDATE_USER_URL = "https://kickasstom.000webhostapp.com/UpdateUser.php?";
    private string UPDATE_USER_SCORE_URL = "https://kickasstom.000webhostapp.com/UpdateUserScore.php?";
    private string GET_USER_DATA_URL = "https://kickasstom.000webhostapp.com/GetUserData.php?";
    private string GET_SINGLE_USER_SCORE_URL = "https://kickasstom.000webhostapp.com/GetSingleUserScore.php?";
    private string GET_BEST_USER_SCORE_URL = "https://kickasstom.000webhostapp.com/GetBestUserScores.php?";
    private string GET_BEST_USER_NAMES_URL = "https://kickasstom.000webhostapp.com/GetBestUserNames.php?";

    public string GetAllUsers()
    {
        WWW post = new WWW(SHOW_ALL_USERS_URL);


        while (!post.isDone)
        {

        }

        if (post.error != null)
        {
            Debug.Log("There was an error getting all Users: " + post.error);
        }



        return post.text;
    }

    public int AddUser(string UserName, string Password)
    {
        //Get an array of all user names in the database
        string[] names = GetAttributeOfAllUsers("Name").Split('\t');

        int userID;
        Debug.Log(names);

        // check if given UserName is already in use
        if(names != null && names.Length > 1)
        {
            userID = names.Length; // userID from the new user

            foreach(string s in names)
            {
                if (s.Equals(UserName))
                    return -1;
            }
        }
        else
        {
            return -1;
        }


        //create hash
        string hash = _CreateMD5(UserName + Password + secretKey);

        //create url to use AddUser.php on the webpage
        string post_url = ADD_USER_URL + "Name=" + WWW.EscapeURL(UserName) + "&Password=" + Password + startingEquipment + "&hash=" + hash;
        Debug.Log(post_url);
        WWW post = new WWW(post_url);

        //wait for process of adding a user to be done
        while (!post.isDone)
        {

        }

        //if there is an error with adding a user return a wrong value(-1)
        if (post.error != null)
        {
            Debug.Log("There was an error posting the user data: " + post.error);
            return -1;
        }

        //create user score entries in the Scores database for all game stages
        if (!CreateUserScoreEntrties(userID, UserName, Password))
            return -1;

        return userID;
    }

    public void updateUser(int UserID, string UserName, string Password, int Money, int LevelProgress, int Hearts, int Bombs, int Shields, int Potions)
    {
        string hash = _CreateMD5(UserName + Password + secretKey);

        string postString = UPDATE_USER_URL + "UserID= "+ UserID
                                        + "&Name=" + UserName
                                        + "&Password=" + Password
                                        + "&Money= " + Money
                                        + "&LevelProgress= " + LevelProgress
                                        + "&Hearts= " + Hearts
                                        + "&Bombs= " + Bombs
                                        + "&Shields= " + Shields
                                        + "&Potions= " + Potions
                                        + "&hash=" + hash;

        Debug.Log(postString);

        WWW post = new WWW(postString);

        while (!post.isDone) { };
        if(post.error != null)
        {
            Debug.Log("There was an error posting the user data: "+post.error);
        }
        else
        {
            Debug.Log("User data was successfully updated");
        }
    }

    public void UpdateUserScore(int UserID, string UserName, string Password, int Stage, int Score)
    {

        string hash = _CreateMD5(UserName + Password + secretKey);
        string postString = UPDATE_USER_SCORE_URL + "UserID=" + UserID + "&Name=" + UserName + "&Password=" + Password + "&Stage=" + Stage + "&Score=" + Score + "&hash=" + hash;
        WWW post = new WWW(UPDATE_USER_SCORE_URL + postString);
        
        Debug.Log(postString);
        while(!post.isDone){ }
        if(post.error != null)
        {
            Debug.Log("There was an error updating the user score: "+post.error);
        }
        else
        {
            Debug.Log("The user score was successfully updated!");
        }
        
    }

    public bool CreateUserScoreEntrties(int UserID, string UserName, string Password)
    {
        string hash = _CreateMD5(UserName + Password + secretKey);


        WWW post;

        for(int i=0; i<5; i++)
        {
            string postString = NEW_USER_SCORE_URL + "UserID=" + UserID + "&Name=" + UserName + "&Password=" + Password + "&Stage=" + (i+1) + "&hash=" + hash;
            post = new WWW(postString);
            Debug.Log(postString);
            while (!post.isDone) { }
            if (post.error != null)
            {
                Debug.Log("There was an error creating new user score entries in the database: " + post.error);
                return false;
            }
            else
            {
                Debug.Log("User score entry "+(i+1)+" was successfully created!");
            }
        }

        return true;
    }

    public string GetAttributeOfAllUsers(string Attribute)
    {
        string s = GET_ATTRIBUTE_OF_ALL_USERS_URL + "Attribute= " + Attribute;
        WWW post = new WWW(s);
        Debug.Log(s);
        while (!post.isDone) { };
        if(post.error != null)
        {
            Debug.Log("There was an error getting the attribute of all users: "+post.error);
            Debug.Log(post.text);
        }

        return post.text;
    }

    public string GetSingleUserScore(int Stage, int UserID)
    {
        WWW post = new WWW(GET_SINGLE_USER_SCORE_URL + "UserID="+UserID+"&Stage="+Stage);
        string s = GET_SINGLE_USER_SCORE_URL + "UserID=" + UserID + "&Stage=" + Stage;
        Debug.Log(s);
        while (!post.isDone) { };
        if (post.error != null)
        {
            Debug.Log("There was an error getting the score of the user: "+post.error);
        }
        return post.text;
    }

    public string GetBestUserScores(int Stage, int Amount)
    {
        WWW post = new WWW(GET_BEST_USER_SCORE_URL + "Stage="+Stage+"&Amount="+Amount);
        string s = GET_BEST_USER_SCORE_URL + "Stage=" + Stage + "&Amount=" + Amount;
        Debug.Log(s);
        while (!post.isDone) { }
        if(post.error != null)
        {
            Debug.Log("There was an error getting the scores of the best users: "+post.error);
        }
        return post.text;
    }

    public string GetBestUserNames(int Stage, int Amount)
    {
        WWW post = new WWW(GET_BEST_USER_NAMES_URL + "Stage="+Stage+"&Amount="+Amount);
        string s = GET_BEST_USER_NAMES_URL + "Stage=" + Stage + "&Amount=" + Amount;
        Debug.Log(s);
        while (!post.isDone) { }
        if(post.error != null)
        {
            Debug.Log("There was an error getting the names of the best users: "+post.error);
        }
        return post.text;
    }

    public string GetUserData(int UserID)
    {
        WWW post = new WWW(GET_USER_DATA_URL + "UserID=" + UserID);
        string s = GET_USER_DATA_URL + "UserID=" + UserID;
        Debug.Log("GetUserData - post: "+s);
        while (!post.isDone) { };
        if(post.error != null)
        {
            Debug.Log("There was an error getting the user data: "+post.error);
        }

        return post.text;
    }

    private static string _CreateMD5(string input)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }

        return sb.ToString().ToLower();
    }
}
