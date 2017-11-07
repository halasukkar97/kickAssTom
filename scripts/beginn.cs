﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginn : MonoBehaviour {
   
    float delay;
    public GameObject[] aiTom;
    private Transform _target;
    public float startNewDelay = 3;
    int randomai;
    bool gameIsPaused = false;

    // Update is called once per frame

    void Update()
    {
        if (!gameIsPaused)
        {
            if (delay <= 0)
            {
                delay = startNewDelay;
                SpawnNewtom();
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }

    }

    private void SpawnNewtom()
    {
        randomai = Random.Range(0, 3);
        GameObject newAi = Instantiate(aiTom[randomai], this.transform.position,this.transform.rotation);  
        newAi.GetComponent<AI>().Launch(_target);
    }

    public void PauseGame()
    {
        gameIsPaused = true;

    }

    public void ResumeGame()
    {
        gameIsPaused = false;

    }
}
