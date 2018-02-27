using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {
    public GameObject PickupSound;
    public bool isAmmo;
    public float RandomAmmoAmount;
    public float RandomArmorAmount;
    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Transform>().parent = GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().Past.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Transform>().Rotate(0, 3, 0);
	}

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            Instantiate(PickupSound, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
            RandomAmmoAmount = Random.Range(10, 100);
            RandomArmorAmount = Random.Range(20, 60);
            if(isAmmo == true)
            {
                if(Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().WhichWeapon == 0)
                {
                    Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().Pistol.GetComponent<WeaponMechanic>().PistolAmmo += RandomAmmoAmount;
                }
                if (Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().WhichWeapon == 1)
                {
                    Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().Rifle.GetComponent<WeaponMechanic>().RifleAmmo += RandomAmmoAmount;
                }
                if (Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().WhichWeapon == 2)
                {
                    Col.gameObject.GetComponent<PlayerMovement>().SwayPivot.GetComponent<WeaponSystem>().Heavy.GetComponent<WeaponMechanic>().ShotgunAmmo += RandomAmmoAmount;
                }
            }
            else
            {
                Col.gameObject.GetComponent<PlayerMovement>().PlayerArmor += RandomArmorAmount;
            }
            Destroy(gameObject);
        }
    }
}
