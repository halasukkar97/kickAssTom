using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startpoint : MonoBehaviour {

    public GameObject tom_top;
    float delay;
    public float SpawnDelay = 20;

    public GameObject aiTom;
    private Transform _target;
    public float startNewDelay;


	
	// Update is called once per frame
	void Update () {

        if(delay <=0)
            {
                delay = startNewDelay;
            SpawnNewtom();
            }
            else
            {
                delay -= Time.deltaTime;
            }
    }


    private void SpawnNewtom()
    {
        // Instantiate(tom_top);        //, transform.position, transform.rotation);
        GameObject newAi = Instantiate(aiTom, this.transform.position, transform.rotation);   // hon 7ta n2ol mn wen btblsh al bullet
        newAi.GetComponent<AI>().Launch(_target);

    }
}
