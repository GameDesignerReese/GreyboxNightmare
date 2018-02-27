using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour {
    public Vector3 CameraInput;
    public Vector3 OriginalPosition;
    public float Amount;
    public float Smooth;
    // Use this for initialization
    void Start ()
    {
        OriginalPosition = gameObject.GetComponent<Transform>().localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void LateUpdate()
    {
        CameraInput = new Vector3(Input.GetAxis("Mouse X") * Amount, Input.GetAxis("Mouse Y") * Amount, 0);
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(gameObject.GetComponent<Transform>().localPosition, CameraInput + OriginalPosition, Time.deltaTime * Smooth);
    }
}
