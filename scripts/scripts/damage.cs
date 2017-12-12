using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class damage : MonoBehaviour
{
    private GameState m_gamestate = new GameState();
    private Canvas m_canvas;
    private gamewatch _gamewatch;
    public gamescore _gamescore;
    public GameObject[] hearts;
    public int heartCount;
    private AdMob _addmob;
    public GameObject img;

    
    // Use this for initialization
    void Start()
    {
        m_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _addmob = new AdMob();
        hearts = new GameObject[m_gamestate.GetHearts()];
        heartCount = hearts.Length;
        for (int i = 0; i < heartCount; i++)
        {
            if (i % 2 == 0)
            {
                hearts[i] = Canvas.Instantiate(img, new Vector2(m_canvas.transform.position.x + -390 + (i * 30), m_canvas.transform.position.y + 270), Quaternion.identity);
            }
            else
            {
                hearts[i] = Canvas.Instantiate(img, new Vector2(m_canvas.transform.position.x + -380 + (i * 30), m_canvas.transform.position.y + 230), Quaternion.identity);

            }
            hearts[i].transform.parent = m_canvas.transform;
        }


    }

    private void Update()
    {
        Hearts();
    }

    void Hearts()
    {
        

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Damage - OnTriggerEnter");
        if (col.tag.Equals("upAI") || col.tag.Equals("middleAI") || col.tag.Equals("downAI"))
        {

            Debug.Log("Damage - AI_Collision");
            heartCount--;
            Destroy(hearts[heartCount]);
            if (heartCount > 2)
                m_gamestate.AddHearts(-1);

            _gamescore.ResetBonusPoints();

        }

        if (heartCount <= 0)
        {
            // player is dead
            gamewatch.lost = true;
            _addmob.AddBanner();
            m_gamestate.LoadScene(4, true);
            // m_gamestate.GetMoney += _gamescore.money;

        }

    }
}
