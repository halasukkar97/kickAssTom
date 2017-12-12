using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("OnTriggerEnter");

        switch (col.tag)
        {
            case "upAI":
                if (col.gameObject.tag == "upAI")
                    Destroy(col.gameObject);
                break;

            case "middleAI":
                if (col.gameObject.tag == "middleAI")
                    Destroy(col.gameObject);
                break;

            case "downAI":
                if (col.gameObject.tag == "downAI")
                    Destroy(col.gameObject);
                break;
        }

    }
}
