using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   

    float m_Delay;
    public GameObject[] m_Enemies;
    private Transform m_Target;
    public float m_StartNewDelay;
    int m_RandomEmemy;
    private bool m_GameIsPaused;
    private static List<GameObject> AiList = new List<GameObject>();

    private void Start()
    {
        m_GameIsPaused = false; //setting bool to false
 
    }
    // Update is called once per frame
    void Update()
    {
        if (!m_GameIsPaused) //if the game is playing
        {
            if (m_Delay <= 0) //and delay less then 0
            {
                m_Delay = m_StartNewDelay; // create new delay
                SpawnNewAI(); //creat new ai
            }
            else
            {
                m_Delay -= Time.deltaTime; // make delay go backwords
            }
        }

    }

    private void SpawnNewAI() //function to creat new AI
    {
        m_RandomEmemy = Random.Range(0, 3); // send a random AI from up middel or down
        GameObject newAi = Instantiate(m_Enemies[m_RandomEmemy], this.transform.position, this.transform.rotation); // set position and rotaions to the new AI
        newAi.GetComponent<EnemyMovement>().Launch(m_Target); //launch new AI
        AiList.Add(newAi); //add the new ai to the list
    }

    public void PauseGame() // if the game was poused
    {
        m_GameIsPaused = true; //set the bool to true  to stop the ai from moving or launching new ai

    }

    public void ResumeGame() //if the game is resumed 
    {
        m_GameIsPaused = false; //set the bool to false  to make the ai move and launch new ai

    }

    public void DeleteAllEnemies() // this function to kill all the enemy in the list to clear the screen from ai
    {
        foreach(GameObject g in AiList)
        {
            Destroy(g); // remove ai
        }
        AiList.Clear(); // clear the ai list 
    }
}
