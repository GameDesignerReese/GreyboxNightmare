using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {
    public AudioClip[] ConcreteSounds;
    public AudioClip[] MetalSoundsSounds;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FootstepSound()
    {
        gameObject.GetComponent<AudioSource>().clip = ConcreteSounds[Random.Range(0, ConcreteSounds.Length)];
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(1, 1.5f);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
