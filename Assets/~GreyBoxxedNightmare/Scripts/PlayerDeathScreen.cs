using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScreen : MonoBehaviour {
    public GameObject DEATH_MENU;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DisplayDeathMenu()
    {
        DEATH_MENU.SetActive(true);
        Time.timeScale = 0;
    }
}
