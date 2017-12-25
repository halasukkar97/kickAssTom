using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider Col)
    {

        Debug.Log("OnTriggerEnter");

        switch (Col.tag) //check wich ai came in the collider
        {
            case "upAI": //if it was upAI
                if (Col.gameObject.tag == "upAI")
                    Destroy(Col.gameObject); //destroy upAI
                break;

            case "middleAI": //if it was middleAI
                if (Col.gameObject.tag == "middleAI")
                    Destroy(Col.gameObject); //destroy middleAI
                break;

            case "downAI": //if it was downAI
                if (Col.gameObject.tag == "downAI")
                    Destroy(Col.gameObject); //destroy downAI
                break;
        }

    }
}
