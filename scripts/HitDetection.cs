using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HitDetection : MonoBehaviour
{
    private GameManagement m_GameManagement = new GameManagement();
    private Canvas m_Canvas;
    public ScoreEvaluation m_GameScore;


    public static int HEARTCOUNT;
    private static int MAXHEARTS;
    private BannerAdvertisement m_BannerAdvertisement;
    public GameObject m_HeartImage;
    private bool m_ShieldIsON;

    private int m_ShieldUses = 0; //shilds layers



    // Use this for initialization
    void Start()
    {
        m_BannerAdvertisement = new BannerAdvertisement(); //calling the banner 
        m_Canvas = GameObject.Find("Canvas").GetComponent<Canvas>(); //adding the canvas

        m_ShieldIsON = false; //setting the shild bool to false
        HEARTCOUNT = m_GameManagement.GetHearts(); // know how many herts the user has
        MAXHEARTS = HEARTCOUNT; //call to know the maximum hearts the user has
        DrawHearts(); //draw the user hearts by calling the function

    }

    public void DrawHearts() //drawing the hearts function
    {
        //Destroy all displayed hearts
        for(int i=0; i<(HEARTCOUNT + 1); i++)
        {
            GameObject g = GameObject.Find("Heart" + i);
            if (g == null)
                Debug.Log("Cannot find: Heart" + i);
            else
                Destroy(g);

        }

        //draw as many hearts as heartcount
        for (int i = 0; i < HEARTCOUNT; i++)
        {
            //Debug.Log("DrawHearts: i = " + i);
            GameObject Heart;

            //this is where and how to place the new hearts
            if (i % 2 == 0)
            {
                Heart = Canvas.Instantiate(m_HeartImage, new Vector2(m_Canvas.transform.position.x + -1000 + (i * 30), m_Canvas.transform.position.y + 650), Quaternion.identity);
                Heart.name = "Heart" + i;
            }
            else
            {
                Heart = Canvas.Instantiate(m_HeartImage, new Vector2(m_Canvas.transform.position.x + -1000 + (i * 30), m_Canvas.transform.position.y + 600), Quaternion.identity);
                Heart.name = "Heart" + i;

            }
            Heart.transform.parent = m_Canvas.transform; // add the hearts to the canvas
            
        }

    }

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log("Damage - OnTriggerEnter");
        if (Col.tag.Equals("upAI") || Col.tag.Equals("middleAI") || Col.tag.Equals("downAI")) //if one of the enemy enter the collider
        {
            if (!m_ShieldIsON) //if the shild is not on 
            {
                Debug.Log("Damage - AI_Collision");
                HEARTCOUNT--; //remove one of the hearts one by one
                if (HEARTCOUNT > 2) //if the user has less then tow hearts
                    m_GameManagement.AddHearts(-1);//remove one of the hearts

                Debug.Log("GameState - Hearts: " + m_GameManagement.GetHearts());

                m_GameScore.ResetBonusPoints(); //reset the bounes points chain
                DrawHearts(); //call the draw function
            }
            else
                m_ShieldUses--; //remove on of the shilds layer

            if (m_ShieldUses <= 0) //if the user has no shilds 
                m_ShieldIsON = false; //set the shild bool to false



        }

        if (HEARTCOUNT <= 0) //if the user has 0 hearts
        {
            // the player is dead
            InGameTimer.LOST = true;
            m_BannerAdvertisement.ShowBanner(); //show the banner adds
            m_GameManagement.LoadScene(4, true); //open scene 4

        }

    }

    public void AddHearts(int Amount) //add hearts functions
    {
        HEARTCOUNT += Amount;//add hearts to the hearts count
        m_GameManagement.AddHearts(HEARTCOUNT);
        if (HEARTCOUNT > MAXHEARTS) //if the hart count is more then the maximum hearts
        {
            HEARTCOUNT = MAXHEARTS; //set the heart count = to the maximum hearts
            m_GameManagement.SetHearts(MAXHEARTS);
        }
            
    }

    public void SetShieldIsOn(bool Status)  //if the shild is on
    {
        m_ShieldIsON = Status; //set it to on
        if (m_ShieldIsON)
            m_ShieldUses = 3; //give the shild 3 layers

    }

    public bool GetShieldIsOn()
    {
        return m_ShieldIsON;
    }


    
}
