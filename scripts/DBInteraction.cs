using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;

public class DBInteraction {

    private string secretKey = "mySecretKey";
    private string startingEquipment = "&Money=0 &LevelProgress=0 &Hearts=3 &Bombs=0 &Shields=0";

    private string AddUserURL = "https://kickasstom.000webhostapp.com/AddUser.php?";
    private string ShowAllUsersURL = "https://kickasstom.000webhostapp.com/SelectAllUsers.php?";
    private string GetAttributeOfAllUsersURL = "https://kickasstom.000webhostapp.com/GetAttribute.php?";
    private string UpdateUserURL = "https://kickasstom.000webhostapp.com/UpdateUser.php?";
    private string GetUserDataURL = "https://kickasstom.000webhostapp.com/GetUserData.php?";

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

    public bool AddUser(string UserName, string Password)
    {
        //Get an array of all user names in the database
        string[] names = GetAttributeOfAllUsers("Name").Split(' ');

        // check if given UserName is already in use
        if(names != null)
        {
            foreach(string s in names)
            {
                if (s.Equals(UserName))
                    return false;
            }
        }
        else
        {
            return false;
        }


        //create hash
        string hash = CreateMD5(UserName + Password + secretKey);

        //create url to use AddUser.php on the webpage
        string post_url = AddUserURL + "Name= " + WWW.EscapeURL(UserName) + "&Password=" + Password + startingEquipment + "&hash=" + hash;
        Debug.Log(post_url);
        WWW post = new WWW(post_url);

        //wait for process of adding a user to be done
        while (!post.isDone)
        {

        }

        if (post.error != null)
        {
            Debug.Log("There was an error posting the user data: " + post.error);
            return false;
        }

        return true;
    }

    public void updateUser(int userID, string userName, string password, int money, int levelProgress, int hearts, int bombs, int shields)
    {
        string hash = CreateMD5(userName + password + secretKey);

        string post_url = UpdateUserURL + "UserID= "+ userID
                                        + "&Name= " + userName
                                        + "&Password= " + password
                                        + "&Money= " + money
                                        + "&LevelProgress= " + levelProgress
                                        + "&Hearts= " + hearts
                                        + "&Bombs= " + bombs
                                        + "&Shields= " + shields
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
