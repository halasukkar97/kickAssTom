using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{

    public bool m_EnemyUpIsin = false;
    public bool m_EnemyMiddleIsIn = false;
    public bool m_EnemyDownIsIn = false;

    public GameObject m_EnemyUp;
    public GameObject m_EnemyMiddle;
    public GameObject m_EnemyDown;


    public GameObject[] m_hearts;


    void OnTriggerEnter(Collider Col)
    {
        switch (Col.tag)
        {
            case "upAI"://if the upAI enter
                m_EnemyUp = Col.gameObject;
                m_EnemyUpIsin = true; //set the upAI to true

                break;

            case "middleAI"://if the middleAI enter
                m_EnemyMiddle = Col.gameObject;
                m_EnemyMiddleIsIn = true;//set the middleAI to true
                break;

            case "downAI"://if the downAI enter
                m_EnemyDown = Col.gameObject;
                m_EnemyDownIsIn = true;//set the downAI to true
                break;
        }

    }

    void OnTriggerExit(Collider Col) //when ai enter the exit collider
    {
        switch (Col.tag)
        {
            case "upAI":   //if up ai enters
                m_EnemyUpIsin = false; //set the bool to false to remove it
                break;

            case "middleAI": //if middle ai enters
                m_EnemyMiddleIsIn = false;//set the bool to false to remove it
                break;

            case "downAI"://if down ai enters
                m_EnemyDownIsIn = false;//set the bool to false to remove it
                break;
        }
    }
}
