using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealitySystem : MonoBehaviour {
    [Header("Sorry Krister, the int method was needed here :/")]
    public int FutureToggle;
    public Color PastColorSheme;
    public Color FutureColorSheme;
    public GameObject Past;
    public GameObject Future;
    public GameObject PastMusic;
    public GameObject FutureMusic;
    public bool TravelledToFuture;
    public bool TravelledToPast;
    public bool PlayerMechanicsScene;
    public Image DeathScreen;
    public bool KilledAnEnemy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled == 0)
        {
            PastMusic.SetActive(false);
            PastMusic.GetComponent<AudioSource>().mute = true;
            FutureMusic.GetComponent<AudioSource>().mute = true;
        }

        if (PlayerMechanicsScene == false)
        {
            if (DeathScreen.enabled == true)
            {
                PastMusic.SetActive(false);
                PastMusic.GetComponent<AudioSource>().mute = true;
                FutureMusic.GetComponent<AudioSource>().mute = true;
            }
        }

        if (FutureToggle == 1)
        {
            RenderSettings.ambientLight = FutureColorSheme;
            Future.SetActive(true);
            Past.SetActive(false);
            if (PlayerMechanicsScene == false)
            {
                if (GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled == 1)
                {
                    if (DeathScreen.enabled == false)
                    {
                        PastMusic.GetComponent<AudioSource>().mute = true;
                        FutureMusic.GetComponent<AudioSource>().mute = false;
                    }
                }
            }
        }
        else
        {
            RenderSettings.ambientLight = PastColorSheme;
            Future.SetActive(false);
            Past.SetActive(true);
            if (PlayerMechanicsScene == false)
            {
                if (GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled == 1)
                {
                    if (DeathScreen.enabled == false)
                    {
                        PastMusic.SetActive(true);
                        PastMusic.GetComponent<AudioSource>().mute = false;
                        FutureMusic.GetComponent<AudioSource>().mute = true;
                    }
                }
            }
        }

        if(FutureToggle > 1)
        {
            FutureToggle = 0;
        }
	}
}
