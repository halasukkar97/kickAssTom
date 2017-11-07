using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamescene : MonoBehaviour {
    public Pause _pause;

	void Start () {
        _pause._panel.SetActive(false);
    }

}
