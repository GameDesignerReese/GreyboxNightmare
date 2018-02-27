using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public Camera PlayerRawCamera;
    public GameObject Player;
    public float WhichWeapon;
    public bool Aiming;
    public Animator AimPivot;
    public Animator PutAwayPivot;
    public Animator CrosshairHUD;
    public GameObject Pistol;
    public GameObject Rifle;
    public GameObject Heavy;
    public GameObject PistolIcon;
    public GameObject RifleIcon;
    public GameObject ShotgunIcon;
    public float MinFOV = 50;
    public float MaxFOV = 70;
    public float MinFOVV;
    public float MaxFOVV;
    public float Smooth = 0.07f;
    public bool SetUnHide = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("NextWeapon"))
        {
            WhichWeapon += 1;
        }

        if (Input.GetButtonDown("PrevWeapon"))
        {
            WhichWeapon -= 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            WhichWeapon += 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            WhichWeapon -= 1;
        }

        if(WhichWeapon > 2)
        {
            WhichWeapon = 0;
        }

        if (WhichWeapon < 0)
        {
            WhichWeapon = 2;
        }

        if(Aiming == true)
        {
            CrosshairHUD.SetBool("Aim", true);
            PlayerRawCamera.fieldOfView = Mathf.SmoothDamp(PlayerRawCamera.fieldOfView, MinFOV, ref MinFOVV, Smooth);
        }
        else
        {
            CrosshairHUD.SetBool("Aim", false);
            PlayerRawCamera.fieldOfView = Mathf.SmoothDamp(PlayerRawCamera.fieldOfView, MaxFOV, ref MaxFOVV, Smooth);
        }

        if (Player.GetComponent<PlayerMovement>().Sprinting == false)
        {
            if (Input.GetButton("Fire2"))
            {
                Aiming = true;
            }
            else
            {
                Aiming = false;
            }
        }
        else
        {
            Aiming = false;
        }

        if (WhichWeapon == 0)
        {
            SetUnHide = true;
            PistolIcon.SetActive(true);
            if (Player.GetComponent<PlayerMovement>().Sprinting == false)
            {
                if (Input.GetButton("Fire2"))
                {
                    AimPivot.SetBool("PistolAim", true);
                }
                else
                {
                    AimPivot.SetBool("PistolAim", false);
                }
            }
            else
            {
                AimPivot.SetBool("PistolAim", false);
            }
            Pistol.SetActive(true);
            Rifle.SetActive(false);
            Heavy.SetActive(false);
        }
        else
        {
            if(SetUnHide == true)
            {
                PutAwayPivot.SetBool("Hide", false);
                SetUnHide = false;
            }
            PistolIcon.SetActive(false);
            AimPivot.SetBool("PistolAim", false);
        }

        if (WhichWeapon == 1)
        {
            RifleIcon.SetActive(true);
            if (Player.GetComponent<PlayerMovement>().Sprinting == false)
            {
                if (Input.GetButton("Fire2"))
                {
                    AimPivot.SetBool("RifleAim", true);
                }
                else
                {
                    AimPivot.SetBool("RifleAim", false);
                }
            }
            else
            {
                AimPivot.SetBool("RifleAim", false);
            }
            Pistol.SetActive(false);
            Rifle.SetActive(true);
            Heavy.SetActive(false);
        }
        else
        {
            RifleIcon.SetActive(false);
            AimPivot.SetBool("RifleAim", false);
        }

        if (WhichWeapon == 2)
        {
            ShotgunIcon.SetActive(true);
            if (Player.GetComponent<PlayerMovement>().Sprinting == false)
            {
                if (Input.GetButton("Fire2"))
                {
                    AimPivot.SetBool("ShotgunAim", true);
                }
                else
                {
                    AimPivot.SetBool("ShotgunAim", false);
                }
            }
            else
            {
                AimPivot.SetBool("ShotgunAim", false);
            }
            Pistol.SetActive(false);
            Rifle.SetActive(false);
            Heavy.SetActive(true);
        }
        else
        {
            ShotgunIcon.SetActive(false);
            AimPivot.SetBool("ShotgunAim", false);
        }
    }
}
