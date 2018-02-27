using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMechanic : MonoBehaviour {
    public GameObject Player;
    public GameObject RawCamera;
    public GameObject LeaningSystemObject;
    public GameObject HITMARK_HIT;
    public Text ClipHUD;
    public Text AmmoHUD;
    public Image AmmoSliderHUD;
    public Animator WeaponRifleCameraPivot;
    public GameObject Weapon_System;
    public GameObject LazerEffect;
    public Transform LazerSpawn;
    public GameObject MuzzleFlash;
    public Transform MuzzleFlashTransform;
    public GameObject ShootSound;
    public GameObject ClipInSound;
    public GameObject ClipOutSound;
    public Transform Audio_Container;
    public float PistolClip = 12;
    public float PistolAmmo = 40;
    public float RifleClip = 20;
    public float RifleAmmo = 100;
    public float ShotgunClip = 15;
    public float ShotgunAmmo = 100;
    public float PistolDamage = 20;
    public float RifleDamage = 15;
    public float ShotgunDamage = 45;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void PulloutWeapon()
    {
        if(Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            gameObject.GetComponent<Animation>().Play("PistolNormal");
        }
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            gameObject.GetComponent<Animation>().Play("RifleNormal");
        }
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            gameObject.GetComponent<Animation>().Play("ShotgunNormal");
        }
    }

    void ClipsAndAmmoCap()
    {
        if (PistolClip < 0)
        {
            PistolClip = 0;
        }

        if (RifleClip < 0)
        {
            RifleClip = 0;
        }

        if (ShotgunClip < 0)
        {
            ShotgunClip = 0;
        }

        if (PistolAmmo < 0)
        {
            PistolAmmo = 0;
        }

        if (RifleAmmo < 0)
        {
            RifleAmmo = 0;
        }

        if (ShotgunAmmo < 0)
        {
            ShotgunAmmo = 0;
        }
    }

    void WeaponHUD()
    {
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            AmmoSliderHUD.fillAmount = PistolClip / 12;
            ClipHUD.text = "" + PistolClip.ToString();
            AmmoHUD.text = "" + PistolAmmo.ToString();
        }
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            AmmoSliderHUD.fillAmount = RifleClip / 20;
            ClipHUD.text = "" + RifleClip.ToString();
            AmmoHUD.text = "" + RifleAmmo.ToString();
        }
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            AmmoSliderHUD.fillAmount = ShotgunClip / 15;
            ClipHUD.text = "" + ShotgunClip.ToString();
            AmmoHUD.text = "" + ShotgunAmmo.ToString();
        }
    }

	void Update ()
    {
        ClipsAndAmmoCap();
        WeaponHUD();

        if (Input.GetButtonDown("Reload"))
        {
            LeaningSystemObject.GetComponent<LeaningSystem>().LeaningLeft = false;
            LeaningSystemObject.GetComponent<LeaningSystem>().LeaningRight = false;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            if (PistolClip >= 1)
            {
                if (Player.GetComponent<PlayerMovement>().Sprinting == false)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        gameObject.GetComponent<Animation>().Play("PistolShoot");
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("PistolReload");
            }

            if (PistolAmmo >= 1)
            {
                if (Input.GetButtonDown("Reload"))
                {
                    gameObject.GetComponent<Animation>().Play("PistolReload");
                }
            }
        }
 
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            if (gameObject.GetComponent<Animation>().IsPlaying("RifleReload") == true)
            {
                WeaponRifleCameraPivot.SetBool("Shoot", false);
            }

            if (RifleClip >= 1)
            {
                if (Player.GetComponent<PlayerMovement>().Sprinting == false)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        gameObject.GetComponent<Animation>().Play("RifleShoot");
                        WeaponRifleCameraPivot.SetBool("Shoot", true);
                    }
                    else
                    {
                        WeaponRifleCameraPivot.SetBool("Shoot", false);
                    }
                }
                else
                {
                    WeaponRifleCameraPivot.SetBool("Shoot", false);
                }
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("RifleReload");
                WeaponRifleCameraPivot.SetBool("Shoot", false);
            }

            if (RifleAmmo >= 1)
            {
                if (Input.GetButtonDown("Reload"))
                {
                    gameObject.GetComponent<Animation>().Play("RifleReload");
                }
            }
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            if (ShotgunClip >= 1)
            {
                if (Player.GetComponent<PlayerMovement>().Sprinting == false)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        gameObject.GetComponent<Animation>().Play("ShotgunShoot");
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("ShotgunReload");
            }

            if (ShotgunAmmo >= 1)
            {
                if (Input.GetButtonDown("Reload"))
                {
                    gameObject.GetComponent<Animation>().Play("ShotgunReload");
                }
            }
        }
    }

    void Shoot()
    {
        if (RawCamera.GetComponent<RaycastHandler>().CurrentObject != null)
        {
            if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.tag == "Enemy")
            {
                if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth >= 1)
                {
                    RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().Patrolling = false;
                    GameObject BloodObject = Instantiate(RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().Blood, RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>().position, RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>().rotation);
                    BloodObject.GetComponent<Transform>().parent = RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>();
                    GameObject BloodSoundObject = Instantiate(RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().BloodSound, RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>().position, RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>().rotation);
                    BloodSoundObject.GetComponent<Transform>().parent = RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<Transform>();
                    BloodSoundObject.GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
                }
            }
        }
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            if (RawCamera.GetComponent<RaycastHandler>().CurrentObject != null)
            {
                if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.tag == "Enemy")
                {
                    if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth >= 1)
                    {
                        GameObject HitMarker = Instantiate(HITMARK_HIT);
                        PistolDamage = Random.Range(10, 40);
                        RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth -= PistolDamage;
                    }
                }
            }
            PistolClip -= 1;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            if (RawCamera.GetComponent<RaycastHandler>().CurrentObject != null)
            {
                if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.tag == "Enemy")
                {
                    if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth >= 1)
                    {
                        GameObject HitMarker = Instantiate(HITMARK_HIT);
                        RifleDamage = Random.Range(15, 20);
                        RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth -= RifleDamage;
                    }
                }
            }
            RifleClip -= 1;
            GameObject.Find("CROSSHAIR_SHOOT_DETECT").GetComponent<Animation>().Play("CrosshairShootQuick");
        }
        else
        {
            GameObject.Find("CROSSHAIR_SHOOT_DETECT").GetComponent<Animation>().Play("CrosshairShoot");
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            if (RawCamera.GetComponent<RaycastHandler>().CurrentObject != null)
            {
                if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.tag == "Enemy")
                {
                    if (RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth >= 1)
                    {
                        GameObject HitMarker = Instantiate(HITMARK_HIT);
                        ShotgunDamage = Random.Range(20, 80);
                        RawCamera.GetComponent<RaycastHandler>().CurrentObject.GetComponent<EnemyAI>().EnemyHealth -= ShotgunDamage;
                    }
                }
            }
            ShotgunClip -= 1;
            GameObject.Find("CROSSHAIR_SHOOT_DETECT").GetComponent<Animation>().Play("CrosshairShoot");
        }
        GameObject ShootingSound = Instantiate(ShootSound, Audio_Container.position, Audio_Container.rotation);
        ShootingSound.GetComponent<Transform>().parent = Audio_Container.GetComponent<Transform>();
        ShootingSound.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.3f);
        Instantiate(LazerEffect, LazerSpawn.position, LazerSpawn.rotation);
        GameObject MuzzleEffect = Instantiate(MuzzleFlash, MuzzleFlashTransform.position, MuzzleFlashTransform.rotation);
        MuzzleEffect.GetComponent<Transform>().parent = MuzzleFlashTransform;
    }

    void ClipIn()
    {
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            PistolClip = 12;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            RifleClip = 20;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            ShotgunClip = 15;
        }
        GameObject ClipInSoundObject = Instantiate(ClipInSound, Audio_Container.position, Audio_Container.rotation);
        ClipInSoundObject.GetComponent<Transform>().parent = Audio_Container.GetComponent<Transform>();
    }

    void ClipOut()
    {
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            PistolAmmo -= 12;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 1)
        {
            RifleAmmo -= 20;
        }

        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 2)
        {
            ShotgunAmmo -= 15;
        }
        GameObject ClipOutSoundObject = Instantiate(ClipOutSound, Audio_Container.position, Audio_Container.rotation);
        ClipOutSoundObject.GetComponent<Transform>().parent = Audio_Container.GetComponent<Transform>();
    }
}
