using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {
    public float Points;
    public float PointsDecrease;
    public Text PointsAmount;
    public Text PointsAmountDecrease;
    public bool DecreaseAmount;
    public bool PlayDone = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PointsAmount.text = "" + Points.ToString();
        PointsAmountDecrease.text = "" + PointsDecrease.ToString("F0");

        if(DecreaseAmount == true)
        {
            PointsDecrease -= Time.deltaTime * 150;
        }

        if(PointsDecrease <= 0)
        {
            DecreaseAmount = false;
            PointsDecrease = 0;
            if(PlayDone == true)
            {
                gameObject.GetComponent<Animation>().Play("ScoreDone");
                PlayDone = false;
            }
        }
        else
        {
            PlayDone = true;
        }
    }
}
