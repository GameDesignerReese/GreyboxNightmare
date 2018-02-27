using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatDisplay : MonoBehaviour {
    public bool isKills;
    public bool isHighscore;
    public bool isHighestWave;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isKills == true)
        {
            gameObject.GetComponent<Text>().text = GameObject.Find("GAME_DATA").GetComponent<GameData>().Kills.ToString();
        }

        if (isHighscore == true)
        {
            gameObject.GetComponent<Text>().text = GameObject.Find("GAME_DATA").GetComponent<GameData>().Highscore.ToString();
        }

        if (isHighestWave == true)
        {
            gameObject.GetComponent<Text>().text = GameObject.Find("GAME_DATA").GetComponent<GameData>().HighestWave.ToString();
        }
    }
}
