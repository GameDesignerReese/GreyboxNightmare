using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairShoot : MonoBehaviour {

    public Animator Child;
    public GameObject CrosshairShootDetectObject;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(CrosshairShootDetectObject.GetComponent<CrosshairShootDetect>().Shoot == true)
        {
            Child.SetBool("Shoot", true);
        }
        else
        {
            Child.SetBool("Shoot", false);
        }
	}
}
