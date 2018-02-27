using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAmountDisplay : MonoBehaviour {
    public bool isXSensitivity;
    public bool isYSensitivity;
    public bool GameVolume;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isXSensitivity == true)
        {
            gameObject.GetComponent<Text>().text = "" + GameObject.Find("GAME_DATA").GetComponent<GameData>().XSensitivityDisplay.ToString("F0") + "%";
        }
        if (isYSensitivity == true)
        {
            gameObject.GetComponent<Text>().text = "" + GameObject.Find("GAME_DATA").GetComponent<GameData>().YSensitivityDisplay.ToString("F0") + "%";
        }

        if (GameVolume == true)
        {
            gameObject.GetComponent<Text>().text = "" + GameObject.Find("GAME_DATA").GetComponent<GameData>().GameVolumeDisplay.ToString("F0") + "%";
        }
    }
}
