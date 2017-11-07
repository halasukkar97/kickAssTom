using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class Buttons_loadLevel : MonoBehaviour {
    
    public void PlayScene(int level)
    {
        Application.LoadLevel(1);
    }
}
