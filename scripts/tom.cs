using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tom : MonoBehaviour {

    public bool AIup_is_in = false;
    public bool AImiddle_is_in = false;
    public bool AIdown_is_in = false;

    public GameObject enemyUp;
    public GameObject enemyMiddle;
    public GameObject enemyDown;


    public GameObject[] heart;
  

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "upAI":
          //  Debug.Log("OnTriggerEnter up");
                enemyUp = col.gameObject;
                AIup_is_in = true;
                
                break;

            case "middleAI":
          //  Debug.Log("OnTriggerEnter middle");
                enemyMiddle = col.gameObject;
                AImiddle_is_in = true;
                break;

            case "downAI":
            //Debug.Log("OnTriggerEnter down");
                enemyDown = col.gameObject;
                AIdown_is_in = true;
                break;
        }

    }

    void OnTriggerExit(Collider col)
    {
        switch (col.tag)
        {
            case "upAI":
               // Debug.Log("OnTriggerExit up");
                AIup_is_in = false;
                break;

            case "middleAI":
               // Debug.Log("OnTriggerExit middle");
                AImiddle_is_in = false;
                break;

            case "downAI":
               // Debug.Log("OnTriggerExit down");
                AIdown_is_in = false;
                break;
        }
    }
}
