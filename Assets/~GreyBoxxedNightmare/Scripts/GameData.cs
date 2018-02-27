using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
    public bool TESTING;
    public bool AllowResetScore;
    public float XSensitivity = 0.5f;
    public float YSensitivity = 0.5f;
    public float XSensitivityDisplay = 100;
    public float YSensitivityDisplay = 100;
    public float FirstImpression;
    public float Kills;
    public float HighestWave;
    public float Highscore;
    public float GameVolume = 1;
    public float GameVolumeDisplay = 100;
    public bool Ready;
    public bool DefaultXSensitivityPressed;
    public bool DefaultYSensitivityPressed;
    public bool DefaultGameVolumePressed;
    public float MusicEnabled = 1;
    // Use this for initialization
    void Start ()
    {
        XSensitivity = PlayerPrefs.GetFloat("XSensitivity");
        YSensitivity = PlayerPrefs.GetFloat("YSensitivity");
        GameVolume = PlayerPrefs.GetFloat("GameVolume");
        Kills = PlayerPrefs.GetFloat("Kills");
        HighestWave = PlayerPrefs.GetFloat("HighestWave");
        Highscore = PlayerPrefs.GetFloat("Highscore");
        MusicEnabled = PlayerPrefs.GetFloat("MusicEnabled");
        FirstImpression = PlayerPrefs.GetFloat("FirstImpression");

        if (TESTING == false)
        {
            if (GameObject.Find("GAME_DATA"))
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.name = "GAME_DATA";
                DontDestroyOnLoad(gameObject);
            }
        }
        Ready = true;

        if(FirstImpression == 0)
        {
            XSensitivity = 0.5f;
            YSensitivity = 0.5f;
            GameVolume = 1;
            MusicEnabled = 1;
            FirstImpression = 1;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Ready == true)
        {
            PlayerPrefs.SetFloat("XSensitivity", XSensitivity);
            PlayerPrefs.SetFloat("YSensitivity", YSensitivity);
            PlayerPrefs.SetFloat("GameVolume", GameVolume);
            PlayerPrefs.SetFloat("Kills", Kills);
            PlayerPrefs.SetFloat("HighestWave", HighestWave);
            PlayerPrefs.SetFloat("Highscore", Highscore);
            PlayerPrefs.SetFloat("MusicEnabled", MusicEnabled);
            PlayerPrefs.SetFloat("FirstImpression", FirstImpression);
        }

        if(AllowResetScore == true)
        {
            if (Input.GetKey("3"))
            {
                Kills = 0;
                HighestWave = 0;
                Highscore = 0;
            }
        }

        if(MusicEnabled > 1)
        {
            MusicEnabled = 0;
        }

        if(TESTING == true)
        {
            if (Input.GetKey("3"))
            {
                Kills = 0;
                HighestWave = 0;
                Highscore = 0;
            }
        }
        XSensitivityDisplay = XSensitivity * 100;
        YSensitivityDisplay = YSensitivity * 100;
        GameVolumeDisplay = GameVolume * 100;
        AudioListener.volume = GameVolume;
	}
}
