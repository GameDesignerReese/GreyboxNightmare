using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {
    public string WhichScene = "Game";
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SceneLoads()
    {
        SceneManager.LoadScene(WhichScene);
    }
}
