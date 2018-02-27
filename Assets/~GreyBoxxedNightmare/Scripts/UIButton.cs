using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject LoadingScreen;
    public Slider LoadingSlider;
    public GameObject MyMenu;
    public GameObject TargetMenu;
    public Animator TextInside;
    public GameObject HoverSound;
    public GameObject SelectSound;
    public GameObject Checked;
    public Animation Fade_To_Load;
    public bool MusicButton;
    public bool SilentButton;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(MusicButton == true)
        {
            if(GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled == 1)
            {
                Checked.SetActive(true);
            }
            else
            {
                Checked.SetActive(false);
            }
        }
	}

    public void CampaignButtonClicked()
    {
        GameObject SelectSoundObject = Instantiate(SelectSound);
        SelectSoundObject.GetComponent<Transform>().parent = GameObject.Find("SOUNDS").GetComponent<Transform>();
        Fade_To_Load.Play("FadeToLoad");
    }

    public void MenuButtonClicked()
    {
        GameObject SelectSoundObject = Instantiate(SelectSound);
        SelectSoundObject.GetComponent<Transform>().parent = GameObject.Find("SOUNDS").GetComponent<Transform>();
        TargetMenu.SetActive(true);
        MyMenu.SetActive(false);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    public void DefaultButtonClicked()
    {
        GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultXSensitivityPressed = true;
        GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultYSensitivityPressed = true;
        GameObject.Find("GAME_DATA").GetComponent<GameData>().DefaultGameVolumePressed = true;
        GameObject SelectSoundObject = Instantiate(SelectSound);
        SelectSoundObject.GetComponent<Transform>().parent = GameObject.Find("SOUNDS").GetComponent<Transform>();
        GameObject.Find("GAME_DATA").GetComponent<GameData>().XSensitivity = 0.5f;
        GameObject.Find("GAME_DATA").GetComponent<GameData>().YSensitivity = 0.5f;
        GameObject.Find("GAME_DATA").GetComponent<GameData>().GameVolume = 1;
        GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled = 1;
    }

    public void MusicButtonClicked()
    {
        GameObject SelectSoundObject = Instantiate(SelectSound);
        SelectSoundObject.GetComponent<Transform>().parent = GameObject.Find("SOUNDS").GetComponent<Transform>();
        GameObject.Find("GAME_DATA").GetComponent<GameData>().MusicEnabled += 1;
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        if (SilentButton == false)
        {
            GameObject HoverSoundObject = Instantiate(HoverSound);
            HoverSoundObject.GetComponent<Transform>().parent = GameObject.Find("SOUNDS").GetComponent<Transform>();
            TextInside.SetBool("Hover", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SilentButton == false)
        {
            TextInside.SetBool("Hover", false);
        }
    }
}
