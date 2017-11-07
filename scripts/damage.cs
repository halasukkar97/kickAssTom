using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class damage : MonoBehaviour {

    public gamescore _gamescore;
    public GameObject[] img;
    int heartCount;

	// Use this for initialization
	void Start () {
        heartCount = img.Length;
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Damage - OnTriggerEnter");
        if(col.tag.Equals("upAI") || col.tag.Equals("middleAI") || col.tag.Equals("downAI"))
        {

            Debug.Log("Damage - AI_Collision");
            Destroy(img[heartCount - 1]);
            heartCount--;
            _gamescore.ResetBonusPoints();

        }

        if(heartCount <= 0)
        {
            // player is dead
            SceneManager.LoadScene(2);
        }

    }
}
