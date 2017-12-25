using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
 

    public Transform transTom;
    private Transform m_AI;
    private Queue<Vector3> m_Position;
    private Vector3 m_Newtarget;

    public int m_Speed;
    static bool GAME_IS_PAUSED = false;


    // Use this for initialization
    void Start()
    {
        m_Position = new Queue<Vector3>();
        m_Position.Enqueue(transTom.position);
        m_Newtarget = m_Position.Dequeue();              
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!GAME_IS_PAUSED)//if the game is not paused
        {
            if (this.gameObject.transform.position == m_Newtarget)
                Destroy(this.gameObject);

            Move_new();//do movement
        }

    }

    private void Move_new() //set the movment to the enemey
    {
        transform.position = Vector3.MoveTowards(transform.position, m_Newtarget, m_Speed * Time.deltaTime); //move enemy to target
        if (Vector3.Distance(transform.position, m_Newtarget) < 2) //if the distance between target and enemey less then 2
        {
            if (m_Position.Count > 0) // and position count is more then 0
            {
                m_Newtarget = m_Position.Dequeue(); // set enemy new target

            }

        }


    }

    void OnDestroy()  
    {
        Destroy(this.gameObject); //remove this enemey
    }


    public void Launch(Transform trans)
    {
        m_AI = trans; //create new enemy
    }

    public void PauseGame()//in case the pouse button is pressed
    {
        GAME_IS_PAUSED = true; //stop the enemey from movment by settin the bool to true
    }
    public void ResumeGame()//if the resume button is pressed
    {
        GAME_IS_PAUSED = false; // make the enemy move by setting the bool to false

    }

}
