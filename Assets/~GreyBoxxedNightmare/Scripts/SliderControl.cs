using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {
    public bool Ready;
    public bool isXSensitivity;
    public bool isYSensitivity;
    public bool GameVolume;
    // Use this for initialization
    void Start () {
        if (GameObject.Find("GAME_DATA"))
        {
            if(isXSensitivity == true)
            {
                gameObject.GetComponent<Slider>().value = GameObject.Find("GAME_DATA").GetComponent<GameData>().XSensitivity;
            }
            if (isYSensitivity == true)
            {
                gameObject.GetComponent<Slider>().value = GameObject.Find("GAME_DATA").GetComponent<GameData>().YSensitivity;
            }
            if (GameVolume == true)
            {
                gameObject.GetComponent<Slider>().value = GameObject.Find("GAME_DATA").GetComponent<GameData>().GameVolume;
            }
        }
        Ready = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Ready == true)
        {
            if (isXSensitivity == true)
            {
                GameObject.Find("GAME_DATA").GetComponent<GameData>().XSensitivity = gameObject.GetComponent<Slider>().value;
                if(GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultXSensitivityPressed == true)
                {
                    gameObject.GetComponent<Slider>().value = 0.5f;
                    GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultXSensitivityPressed = false;
                }
            }
            if (isYSensitivity == true)
            {
                 GameObject.Find("GAME_DATA").GetComponent<GameData>().YSensitivity = gameObject.GetComponent<Slider>().value;
                if (GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultYSensitivityPressed == true)
                {
                    gameObject.GetComponent<Slider>().value = 0.5f;
                    GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultYSensitivityPressed = false;
                }
            }
            if (GameVolume == true)
            {
                GameObject.Find("GAME_DATA").GetComponent<GameData>().GameVolume = gameObject.GetComponent<Slider>().value;
                if (GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultGameVolumePressed == true)
                {
                    gameObject.GetComponent<Slider>().value = 1;
                    GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultGameVolumePressed = false;
                }
            }
        }
	}
}
