using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour {
    public float Wave;
    public float ZombieDamage = 10;
    public float SoldierDamage = 5;
    public float EnemiesKilled;
    public bool FirstWave;
    public GameObject REALITY_SYSTEM;
    public Text WaveText;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        WaveText.text = "WAVE " + Wave.ToString();
		if(EnemiesKilled > 7)
        {
            GameObject.Find("WAVE_DISPLAY").GetComponent<Animation>().Play("DisplayWave");
            Wave += 1;
            ZombieDamage += 5;
            SoldierDamage += 2;
            EnemiesKilled = 0;
        }

        if(REALITY_SYSTEM.GetComponent<RealitySystem>().KilledAnEnemy == true)
        {
            if(FirstWave == false)
            {
                GameObject.Find("WAVE_DISPLAY").GetComponent<Animation>().Play("DisplayWave");
                Wave += 1;
                FirstWave = true;
            }
        }

        if(Wave > GameObject.Find("GAME_DATA").GetComponent<GameData>().HighestWave)
        {
            GameObject.Find("GAME_DATA").GetComponent<GameData>().HighestWave = Wave;
        }
	}
}
