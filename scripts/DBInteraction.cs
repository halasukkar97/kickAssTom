using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;

public class DBInteraction {

    private string secretKey = "mySecretKey";
    private string startingEquipment = "&Money=0 &LevelProgress=0 &Hearts=3 &Bombs=0 &Shields=0 &Potions=0";

    private string AddUserURL = "https://kickasstom.000webhostapp.com/AddUser.php?";
    private string NewUserScoreURL = "https://kickasstom.000webhostapp.com/NewUserScore.php?";
    private string ShowAllUsersURL = "https://kickasstom.000webhostapp.com/SelectAllUsers.php?";
    private string GetAttributeOfAllUsersURL = "https://kickasstom.000webhostapp.com/GetAttribute.php?";
    private string UpdateUserURL = "https://kickasstom.000webhostapp.com/UpdateUser.php?";
    private string UpdateUserScoreURL = "https://kickasstom.000webhostapp.com/UpdateUserScore.php?";
    private string GetUserDataURL = "https://kickasstom.000webhostapp.com/GetUserData.php?";
    private string GetSingleUserScoreURL = "https://kickasstom.000webhostapp.com/GetSingleUserScore.php?";
    private string GetBestUserScoresURL = "https://kickasstom.000webhostapp.com/GetBestUserScores.php?";
    private string GetBestUserNamesURL = "https://kickasstom.000wwebhostapp.com/GetBestUserNames.php?";

    public string GetAllUsers()
    {
        WWW post = new WWW(ShowAllUsersURL);


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
        string[] names = GetAttributeOfAllUsers("Name").Split(' ');

        int userID;

        // check if given UserName is already in use
        if(names != null)
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
        string hash = CreateMD5(UserName + Password + secretKey);

        //create url to use AddUser.php on the webpage
        string post_url = AddUserURL + "Name=" + WWW.EscapeURL(UserName) + "&Password=" + Password + startingEquipment + "&hash=" + hash;
        Debug.Log(post_url);
        WWW post = new WWW(post_url);

        //wait for process of adding a user to be done
        while (!post.isDone)
        {

        }

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
        string hash = CreateMD5(UserName + Password + secretKey);

        string post_url = UpdateUserURL + "UserID= "+ UserID
                                        + "&Name= " + UserName
                                        + "&Password= " + Password
                                        + "&Money= " + Money
                                        + "&LevelProgress= " + LevelProgress
                                        + "&Hearts= " + Hearts
                                        + "&Bombs= " + Bombs
                                        + "&Shields= " + Shields
                                        + "&Potions= " + Potions
                                        + "&Hash= " + hash;

        Debug.Log(post_url);

        WWW post = new WWW(post_url);

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

    public void updateUserScore(int UserID, string UserName, string Password, int Stage, int Score)
    {

        string hash = CreateMD5(UserName + Password + secretKey);
        WWW post = new WWW(UpdateUserScoreURL + "UserID="+UserID+"&Stage="+Stage+"&Score="+Score+"&hash="+hash);
        string s = UpdateUserScoreURL + "UserID=" + UserID + "&Stage=" + Stage + "&Score=" + Score;
        Debug.Log(s);
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
        string hash = CreateMD5(UserName + Password + secretKey);
        WWW post = new WWW(NewUserScoreURL + "UserID="+UserID+"&hash="+hash);
        string s = NewUserScoreURL + "UserID=" + UserID + "&hash=" + hash;
        Debug.Log(s);
        while (!post.isDone) { }
        if(post.error != null)
        {
            Debug.Log("There was an error creating new user score entries in the database: "+post.error);
            return false;
        }
        else
        {
            Debug.Log("User score entries were successfully created!");
            return true;
        }
    }
    public string GetAttributeOfAllUsers(string attribute)
    {
        WWW post = new WWW(GetAttributeOfAllUsersURL+"Attribute= "+attribute);
        string s = GetAttributeOfAllUsersURL + "Attribute= " + attribute;
        Debug.Log(s);
        while (!post.isDone) { };
        if(post.error != null)
        {
            Debug.Log("There was an error getting the attribute of all users: "+post.error);
        }

        return post.text;
    }

    public string GetSingleUserScore(int Stage, int UserID)
    {
        WWW post = new WWW(GetSingleUserScoreURL + "UserID="+UserID+"&Stage="+Stage);
        string s = GetSingleUserScoreURL + "UserID=" + UserID + "&Stage=" + Stage;
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
        WWW post = new WWW(GetBestUserScoresURL + "Stage="+Stage+"&Amount="+Amount);
        string s = GetBestUserScoresURL + "Stage=" + Stage + "&Amount=" + Amount;
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
        WWW post = new WWW(GetBestUserNamesURL + "Stage="+Stage+"&Amount="+Amount);
        string s = GetBestUserNamesURL + "Stage=" + Stage + "&Amount=" + Amount;
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
        WWW post = new WWW(GetUserDataURL + "UserID=" + UserID);
        string s = GetUserDataURL + "UserID=" + UserID;
        Debug.Log("GetUserData - post: "+s);
        while (!post.isDone) { };
        if(post.error != null)
        {
            Debug.Log("There was an error getting the user data: "+post.error);
        }

        return post.text;
    }

    private static string CreateMD5(string input)
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
