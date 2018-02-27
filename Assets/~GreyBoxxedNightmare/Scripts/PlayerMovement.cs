using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float PlayerHealth = 100;
    public float PlayerArmor;
    public GameObject ArmorHUD;
    public Text ArmorAmount;
    public GameObject PAUSE_MENU;
    public GameObject FootstepSounds;
    public GameObject Player_Pistol_Sprint;
    public GameObject Player_Arm_Interaction;
    public GameObject SwayPivot;
    public Transform PlayerCamera;
    public Transform DeadCameraPivotTransform;
    public Animator Blood_Effect;
    public Animator DeadCameraPivot;
    public Animator PutawayPivot;
    public Animator MovePivot;
    public Animator SprintPivot;
    public Animator WeaponCamera;
    public Animator RawCamera;
    public Animator CrosshairHUD;
    public Animator CrosshairHUDPivot;
    public Animator RawCameraPivot;
    public float XRotation;
    public float YRotation;
    public float XRotationV;
    public float YRotationV;
    public float XRotationCurrent;
    public float YRotationCurrent;
    public float Smooth = 0.1f;
    public float XSensitivity = 0.5f;
    public float YSensitivity = 0.5f;
    public float Speed = 5;
    public float JumpSpeed = 5;
    public float JetpackSpeed = 2;
    public bool FuturePeriod;
    public GameObject[] TimePeriod;
    public bool Sprinting;
    public bool CrouchToggle;
    public float MaxHeight = 2;
    public float MinHeight = 0.5f;
    public float MaxHeightV;
    public float MinHeightV;
    public bool DoubleJump;
    public GameObject DoubleJumpSound;
    public bool AllowWeaponCameraSprint = true;
    public bool AllowSprintPivot = true;
    public bool PermanentCrouch;
    public bool Paused;
    // Use this for initialization
    void Start () {
        XSensitivity = GameObject.Find("GAME_DATA").GetComponent<GameData>().XSensitivity;
        YSensitivity = GameObject.Find("GAME_DATA").GetComponent<GameData>().YSensitivity;
        AudioListener.volume = GameObject.Find("GAME_DATA").GetComponent<GameData>().GameVolume;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(PlayerArmor <= 0)
        {
            ArmorHUD.SetActive(false);
            PlayerArmor = 0;
        }
        else
        {
            ArmorHUD.SetActive(true);
            ArmorAmount.text = "" + PlayerArmor.ToString() + "%";
        }

        if(PlayerHealth < 100)
        {
            PlayerHealth += Time.deltaTime * 5;
        }
        else
        {
            PlayerHealth = 100;
        }

        if(PlayerHealth <= 35)
        {
            Blood_Effect.SetBool("Hurt", true);
        }
        else
        {
            Blood_Effect.SetBool("Hurt", false);
        }

        if(PlayerHealth < 1)
        {
            PlayerHealth = 0;
            DeadCameraPivot.gameObject.GetComponent<Transform>().parent = DeadCameraPivotTransform;
            DeadCameraPivot.gameObject.GetComponent<Transform>().position = DeadCameraPivotTransform.position;
            DeadCameraPivot.gameObject.GetComponent<Transform>().rotation = DeadCameraPivotTransform.rotation;
            DeadCameraPivot.SetBool("Dead", true);
            FootstepSounds.SetActive(false);
            Player_Pistol_Sprint.SetActive(false);
            Player_Arm_Interaction.SetActive(false);
            PutawayPivot.SetBool("Hide", true);
            SwayPivot.GetComponent<WeaponSystem>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            if(Paused == true)
            {
                PAUSE_MENU.SetActive(true);
                Time.timeScale = 0;
                if (Input.GetKeyDown("escape"))
                {
                    Paused = false;
                }
            }
            else
            {
                PAUSE_MENU.SetActive(false);
                Time.timeScale = 1;
                if (Input.GetKeyDown("escape"))
                {
                    Paused = true;
                }
            }
        }

        /*
        if(FuturePeriod == true)
        {
            if (Input.GetKeyDown("z"))
            {
                TimePeriod[0].SetActive(true);
                TimePeriod[1].SetActive(false);
                Debug.Log("I'm in the past");
                FuturePeriod = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("z"))
            {
                TimePeriod[0].SetActive(false);
                TimePeriod[1].SetActive(true);
                Debug.Log("I'm in the future");
                FuturePeriod = true;
            }
        }
        */

        if (CrouchToggle == true)
        {
            RawCameraPivot.SetBool("Crouch", true);
            gameObject.GetComponent<CharacterController>().height = Mathf.SmoothDamp(gameObject.GetComponent<CharacterController>().height, MinHeight, ref MinHeightV, Smooth);
            if (PermanentCrouch == false)
            {
                if (Input.GetButtonDown("Crouch"))
                {
                    CrouchToggle = false;
                }
            }
        }
        else
        {
            RawCameraPivot.SetBool("Crouch", false);
            gameObject.GetComponent<CharacterController>().height = Mathf.SmoothDamp(gameObject.GetComponent<CharacterController>().height, MaxHeight, ref MaxHeightV, Smooth);
            if (Input.GetButtonDown("Crouch"))
            {
                CrouchToggle = true;
            }
        }

        /*
        if(TimeToggle > 1)
        {
            TimeToggle = 0;
        }

        if(TimeToggle == 1)
        {
            PastMessage = true;
            if(FutureMessage == true)
            {
                Debug.Log("I'm in the future yay!! :)");
                FutureMessage = false;
            }
        }
        else
        {
            FutureMessage = true;
            if (PastMessage == true)
            {
                Debug.Log("I'm in the past yay!! :)");
                PastMessage = false;
            }
        }

        if (Input.GetKeyDown("f"))
        {
            TimeToggle += 1;
        }
        */

        Movement();
        CameraControl();

    }

    void Movement()
    {
        Vector3 PlayerForward = gameObject.GetComponent<Transform>().TransformDirection(Vector3.forward);
        Vector3 PlayerRight = gameObject.GetComponent<Transform>().TransformDirection(Vector3.right);

        if(Sprinting == true)
        {
            CrosshairHUDPivot.SetBool("Bob", true);
            CrosshairHUD.SetBool("Sprint", true);
            MovePivot.SetBool("Aim", false);
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                MovePivot.SetBool("Aim", true);
            }
            else
            {
                MovePivot.SetBool("Aim", false);
            }
            CrosshairHUDPivot.SetBool("Bob", false);
            CrosshairHUD.SetBool("Sprint", false);
        }

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            CrosshairHUD.SetBool("Run", true);

            if (CrouchToggle == false)
            {
                if (Input.GetButton("Sprint"))
                {
                    if (gameObject.GetComponent<CharacterController>().isGrounded == true)
                    {
                        Sprinting = true;
                        Speed = 9;
                        MovePivot.speed = 1.3f;
                        RawCamera.SetBool("Sprint", true);
                        if (AllowWeaponCameraSprint == true)
                        {
                            WeaponCamera.SetBool("Sprint", true);
                        }
                        else
                        {
                            WeaponCamera.SetBool("Sprint", false);
                        }
                        if (AllowSprintPivot == true)
                        {
                            SprintPivot.SetBool("Sprint", true);
                        }
                        else
                        {
                            SprintPivot.SetBool("Sprint", false);
                        }
                        if (gameObject.GetComponent<CharacterController>().isGrounded == true)
                        {
                            MovePivot.SetBool("Run", true);
                        }
                        else
                        {
                            MovePivot.SetBool("Run", false);
                        }
                    }
                    else
                    {
                        //This is the copy
                        Sprinting = false;
                        if (Input.GetButton("Fire2"))
                        {
                            MovePivot.speed = 0.4f;
                            Speed = 4;
                        }
                        else
                        {
                            MovePivot.speed = 1;
                            Speed = 5;
                        }
                        RawCamera.SetBool("Sprint", false);
                        WeaponCamera.SetBool("Sprint", false);
                        SprintPivot.SetBool("Sprint", false);

                        if (Input.GetButton("Fire2"))
                        {
                            MovePivot.SetBool("Run", false);
                        }
                        else
                        {
                            if (gameObject.GetComponent<CharacterController>().isGrounded == true)
                            {
                                MovePivot.SetBool("Run", true);
                            }
                            else
                            {
                                MovePivot.SetBool("Run", false);
                            }
                        }
                    }
                }
                else
                {
                    Sprinting = false;
                    if (Input.GetButton("Fire2"))
                    {
                        MovePivot.speed = 0.4f;
                        Speed = 4;
                    }
                    else
                    {
                        MovePivot.speed = 1;
                        Speed = 5;
                    }
                    RawCamera.SetBool("Sprint", false);
                    WeaponCamera.SetBool("Sprint", false);
                    SprintPivot.SetBool("Sprint", false);

                    if (Input.GetButton("Fire2"))
                    {
                        MovePivot.SetBool("Run", false);
                    }
                    else
                    {
                        if (gameObject.GetComponent<CharacterController>().isGrounded == true)
                        {
                            MovePivot.SetBool("Run", true);
                        }
                        else
                        {
                            MovePivot.SetBool("Run", false);
                        }
                    }
                }
            }
            else
            {
                Speed = 4;
                MovePivot.speed = 0.4f;

                if (PermanentCrouch == false)
                {
                    if (Input.GetButton("Sprint"))
                    {
                        CrouchToggle = false;
                    }
                }
                else
                {
                    CrouchToggle = true;
                }

                if (Input.GetButton("Fire2"))
                {
                    MovePivot.SetBool("Run", false);
                }
                else
                {
                    if (gameObject.GetComponent<CharacterController>().isGrounded == true)
                    {
                        MovePivot.SetBool("Run", true);
                    }
                    else
                    {
                        MovePivot.SetBool("Run", false);
                    }
                }
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                gameObject.GetComponent<CharacterController>().SimpleMove(PlayerForward * Speed);
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                gameObject.GetComponent<CharacterController>().SimpleMove(PlayerForward * -Speed);
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                gameObject.GetComponent<CharacterController>().SimpleMove(PlayerRight * Speed);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                gameObject.GetComponent<CharacterController>().SimpleMove(PlayerRight * -Speed);
            }
        }
        else
        {
            Sprinting = false;
            CrosshairHUD.SetBool("Run", false);
            if (CrouchToggle == false)
            {
                if (Input.GetButton("Fire2"))
                {
                    Speed = 4;
                    MovePivot.speed = 0.4f;
                }
                else
                {
                    Speed = 5;
                    MovePivot.speed = 1;
                }
            }
            else
            {
                Speed = 4;
                MovePivot.speed = 0.4f;
            }
            RawCamera.SetBool("Sprint", false);
            WeaponCamera.SetBool("Sprint", false);
            SprintPivot.SetBool("Sprint", false);
            MovePivot.SetBool("Run", false);
            gameObject.GetComponent<CharacterController>().SimpleMove(PlayerForward * 0);
        }

        if (gameObject.GetComponent<CharacterController>().isGrounded == true)
        {
            DoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                CrouchToggle = false;
                gameObject.GetComponent<CharacterController>().Move(new Vector3(0, JumpSpeed, 0));
            }
        }
        else
        {
            if (DoubleJump == true)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    GameObject DoubleJumpSoundObject = Instantiate(DoubleJumpSound, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                    DoubleJumpSoundObject.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();
                    DoubleJumpSoundObject.GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
                    gameObject.GetComponent<CharacterController>().Move(new Vector3(0, JetpackSpeed, 0));
                    DoubleJump = false;
                }
            }
        }
    }

    void CameraControl()
    {
        if(PlayerHealth < 1)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (Paused == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        XRotation = Mathf.Clamp(XRotation, -80, 80);

        gameObject.GetComponent<Transform>().rotation = PlayerCamera.rotation;

        XRotation += Input.GetAxis("Mouse Y") * XSensitivity * 7;
        YRotation += Input.GetAxis("Mouse X") * YSensitivity * 7;

        XRotationCurrent = Mathf.SmoothDamp(XRotationCurrent, XRotation, ref XRotationV, Smooth);
        YRotationCurrent = Mathf.SmoothDamp(YRotationCurrent, YRotation, ref YRotationV, Smooth);

        PlayerCamera.rotation = Quaternion.Euler(-XRotationCurrent, YRotationCurrent, 0);
    }


}










