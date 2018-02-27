using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPunchSound : MonoBehaviour {
    public AudioClip[] PunchSounds;
	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<AudioSource>().clip = PunchSounds[Random.Range(0, PunchSounds.Length)];
        gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
