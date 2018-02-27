using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMusicCheck : MonoBehaviour {
    public bool isMenuMusic;
	// Use this for initialization
	void Start () {
		if(isMenuMusic == true)
        {
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled == 1)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }

        if(isMenuMusic == true)
        {
            if (GameObject.Find("REALITY_SYSTEM"))
            {
                Destroy(gameObject);
            }
        }
	}
}
