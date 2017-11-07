using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public Transform[] transarray;
    private Transform _AI;
    private Queue<Vector3> _position;
    Vector3 newtarget;
   
    public int speed = 5;
    static bool gameIsPaused = false;
    // Use this for initialization
    void Start () {

        _position = new Queue<Vector3>();
        foreach (var target in transarray)
         _position.Enqueue(target.position);     //target ist ein tranform
        newtarget = _position.Dequeue();              // newtarget ist unsere aktuelle ziel 
                                                      //lma nwsal l awal n2ta asma newtarget btnm7a w beser al n2ta al taneh asma newtarget

    }

    // Update is called once per frame
    void Update () {
        if(!gameIsPaused)
        {
            if (this.gameObject.transform.position == newtarget)
                Destroy(this.gameObject);
            Move_new();
        }
       
    }


    private void Move_old()
    {
        if (transform.position.z < 10)
            //transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed);
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
        {

            transform.Rotate(new Vector3(0, 180, 0));

            //transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + (speed* transform.forward).z);
            transform.position += transform.forward * (speed * Time.deltaTime);
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
