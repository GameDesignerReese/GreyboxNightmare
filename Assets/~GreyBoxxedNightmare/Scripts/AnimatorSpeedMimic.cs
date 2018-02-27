using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedMimic : MonoBehaviour {
    public float MinVolume = 0.4f;
    public float MaxVolume = 1;
    public float MinVolumeV;
    public float MaxVolumeV;
    public float Smooth = 0.2f;
    public CharacterController Player;
    public Animator MovePivot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Animator>().speed = MovePivot.speed;

        if (Player.isGrounded == true)
        {
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetButton("Sprint"))
                {
                    gameObject.GetComponent<AudioSource>().volume = Mathf.SmoothDamp(gameObject.GetComponent<AudioSource>().volume, MaxVolume, ref MaxVolumeV, Smooth);
                }
                else
                {
                    gameObject.GetComponent<AudioSource>().volume = Mathf.SmoothDamp(gameObject.GetComponent<AudioSource>().volume, MinVolume, ref MinVolumeV, Smooth);
                }
                gameObject.GetComponent<Animator>().SetBool("Run", true);
            }
            else
            {
                gameObject.GetComponent<AudioSource>().volume = Mathf.SmoothDamp(gameObject.GetComponent<AudioSource>().volume, MinVolume, ref MinVolumeV, Smooth);
                gameObject.GetComponent<Animator>().SetBool("Run", false);
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = Mathf.SmoothDamp(gameObject.GetComponent<AudioSource>().volume, MinVolume, ref MinVolumeV, Smooth);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
    }
}
