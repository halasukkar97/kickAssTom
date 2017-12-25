using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTimer : MonoBehaviour {

    public GameObject m_Ememy;
    float m_Delay;
    private Transform m_Target;
    public float m_StartNewDelay;


	
	// Update is called once per frame
	void Update () {

        if(m_Delay <= 0)//if the delay time is less or 0
            {
            m_Delay = m_StartNewDelay; // start new delay time 
            SpawnNewAI(); //creat and launch new ai
            }
            else
            {
            m_Delay -= Time.deltaTime; // make delay go backwords
        }
    }


    private void SpawnNewAI() //function to creat new AI
    {
        // Instantiate AI Tom    
        GameObject newAi = Instantiate(m_Ememy, this.transform.position, transform.rotation);  // set position and rotaions to the new AI
        newAi.GetComponent<EnemyMovement>().Launch(m_Target); //launch new ai and send it to target 

    }
}
