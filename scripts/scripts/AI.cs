using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
 

    public Transform transTom;
    private Transform _AI;
    private Queue<Vector3> _position;
    Vector3 newtarget;

    public int speed;
    static bool gameIsPaused = false;
    // Use this for initialization
    void Start()
    {

        _position = new Queue<Vector3>();
        _position.Enqueue(transTom.position);     
        newtarget = _position.Dequeue();              
                                                     

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsPaused)
        {
            if (this.gameObject.transform.position == newtarget)
                Destroy(this.gameObject);
            Move_new();
        }

    }

    private void Move_new()
    {
        transform.position = Vector3.MoveTowards(transform.position, newtarget, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, newtarget) < 2)
        {
            if (_position.Count > 0)
            {
                newtarget = _position.Dequeue();

            }

        }


    }

    void OnDestroy()   // had l ele bdo eser abl ma emot al minion
    {
        Destroy(this.gameObject);
    }


    public void Launch(Transform trans)
    {
        _AI = trans;
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
