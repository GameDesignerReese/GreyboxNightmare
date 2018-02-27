using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class PauseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color NonSelectedColor;
    public Color SelectedColor;
    public Text ButtonText;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ContinueButtonClicked()
    {
        Player.GetComponent<PlayerMovement>().Paused = false;
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("LoadingGame");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonText.color = SelectedColor;
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        ButtonText.color = NonSelectedColor;
    }
}
