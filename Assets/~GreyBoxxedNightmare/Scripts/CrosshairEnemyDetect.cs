using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairEnemyDetect : MonoBehaviour {
    public GameObject RaycastCamera;
    public Color NormalColor;
    public Color DetectedColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (RaycastCamera.GetComponent<RaycastHandler>().CurrentObject != null)
        {
            {
                if (RaycastCamera.GetComponent<RaycastHandler>().CurrentObject.tag == "Enemy")
                {
                    gameObject.GetComponent<Image>().color = DetectedColor;
                }
                else
                {
                    gameObject.GetComponent<Image>().color = NormalColor;
                }
            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = NormalColor;
        }
	}
}
