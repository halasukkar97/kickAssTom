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
        // Instantiate AI Tom    
        GameObject newAi = Instantiate(aiTom, this.transform.position, transform.rotation);   // from here AI start to come 
        newAi.GetComponent<AI>().Launch(_target);

    }
}
