using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class damage : MonoBehaviour
{
    private GameState m_gamestate = new GameState();

    private gamewatch _gamewatch;
    public gamescore _gamescore;
    public GameObject[] img;
    int heartCount;
    private AddMob _addmob;

    // Use this for initialization
    void Start()
    {
        _addmob = new AddMob();
        heartCount = img.Length;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Damage - OnTriggerEnter");
        if (col.tag.Equals("upAI") || col.tag.Equals("middleAI") || col.tag.Equals("downAI"))
        {

            Debug.Log("Damage - AI_Collision");
            Destroy(img[heartCount - 1]);
            heartCount--;
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
