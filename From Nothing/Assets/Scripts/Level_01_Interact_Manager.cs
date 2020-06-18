using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;
public class Level_01_Interact_Manager : MonoBehaviour
{

    public static Vector3 elevatorEnterSpot;
    public static Vector3 camSpot;
    public static Vector3 camSpotNew;
    public static bool elevatorButtonPressed = false;
    public static bool level2Access = false;
    public static bool level3Access = false;
    public static bool level4Access = false;
    public static bool level5Access = false;
    public static int floor = 5;

    public GameObject elevatorPanel;
    public GameObject equipmentPanel;
    public bool exitEnablePlayer = true;
    public GameObject pauseScript;

    private GameObject player;
    private GameObject camera;
    public GameObject gloveIcon;
    private GameObject messagePanel;
    private GameObject closestDoor;
    private GameObject closestEnterSpot;
    private GameObject closestExitSpot;
    private Text messageName;
    private Text messageText;
    private Vector3 doorEnterSpotNext;
    private Vector3 doorEnterSpotNextCustom;
    private bool customEnterSpot = false;
    private bool customEnterSpotElevator = false;
    private bool doorEntered;
    private bool bossDoorEntered;

    //status variables
    #region

    //enter door status
    private bool doorEnter;
    public static int doorEnterStatus = 0;
    //elevator status
    public bool elevatorActive;
    public static int elevatorStatus = 0;
    //crystal launcher status
    private bool active01;
    public static int status01 = 0;
    //door 01 button status
    private bool active02;
    public static int status02 = 0;
    //boss door pass status
    private bool active03;
    public static int status03 = 1;
    //boots status
    private bool activeBoots;
    public static int statusBoots = 0;
    //tube status
    private bool activeTube;
    public static int statusTube = 0;
    //keycard01 status
    private bool activeKeycard01;
    public static int statusKeycard = 0;
    //keycard02 status
    private bool activeKeycard02;
    public static int statusKeycard2 = 0;
    //keycard03 status
    private bool activeKeycard03;
    public static int statusKeycard3 = 0;
    //double jump boots status
    private bool activeBoots2;
    public static int statusBoots2 = 0;
    //crystal 2 status
    private bool activeCrystal2;
    public static int statusCrystal2 = 0;
    //crystal 3 status
    private bool activeCrystal3;
    public static int statusCrystal3 = 0;
    //crystal launcher lvl 3 status
    private bool activeLauncherLvl3;
    public static int statusLauncherLvl3 = 0;
    //crystal 4 status
    private bool activeCrystal4;
    public static int statusCrystal4 = 0;
    //glove status
    private bool activeGlove;
    public static int statusGlove = 0;

    #endregion

    private void Awake()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
        messagePanel = GameObject.Find("MessagePanel");
        messageName = GameObject.Find("MessageName").GetComponent<Text>();
        messageText = GameObject.Find("MessageText").GetComponent<Text>();
        closestDoor = GameObject.FindGameObjectWithTag("Door");
        closestEnterSpot = GameObject.FindGameObjectWithTag("DoorEnterSpot");
        closestExitSpot = GameObject.FindGameObjectWithTag("DoorExitSpot");
    }

    //door enter/exit logic
    //message box logic
    #region

    private void Update()
    {
        //entering door
        if (doorEnter)
        {
            player.GetComponent<PlayerController>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //crystal insert status
            if (active01)
            {
                //normal message exit
                if (status01 == 0 || status01 == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    active01 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
                //crystal inserted
                else if (status01 == 1)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    active01 = false;
                    status01 = 2;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //crystal2 insert status
            if (activeCrystal2)
            {
                //normal message exit
                if (statusCrystal2 == 0 || statusCrystal2 == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeCrystal2 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
                //crystal inserted
                else if (statusCrystal2 == 1)
                {
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeCrystal2 = false;
                    statusCrystal2 = 2;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //crystal3 insert status
            if (activeCrystal3)
            {
                //normal message exit
                if (statusCrystal3 == 0 || statusCrystal3 == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeCrystal3 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
                //crystal inserted
                else if (statusCrystal3 == 1)
                {
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeCrystal3 = false;
                    statusCrystal3 = 2;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //crystal launcher lvl3 2 status
            if (activeCrystal4)
            {
                //normal message exit
                if (statusCrystal4 == 0 || statusCrystal4 == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeCrystal3 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
                //button pressed
                else if (statusCrystal4 == 1)
                {
                    GameObject.Find("forceWallRed").GetComponent<Animation>().Play();
                    GameObject.Find("forceWallRed").GetComponentInChildren<Collider2D>().enabled = false;
                    messageName.text = "You";
                    messageText.text = "Well that did something.";
                    statusLauncherLvl3 = 2;
                }
                //exit message
                else if (statusLauncherLvl3 == 2 || statusLauncherLvl3 == 4)
                {
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeLauncherLvl3 = false;
                    statusLauncherLvl3 = 3;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //crystal launcher lvl3 status
            if (activeLauncherLvl3)
            {
                //you power it on
                if (statusLauncherLvl3 == 0)
                {
                    messageName.text = "";
                    messageText.text = "You notice that a button needs to be pressed to turn on the power.";
                    statusLauncherLvl3 = 1;
                }
                //button pressed
                else if (statusLauncherLvl3 == 1)
                {
                    GameObject.Find("forceWallRed").GetComponent<Animation>().Play();
                    GameObject.Find("forceWallRed").GetComponentInChildren<Collider2D>().enabled = false;
                    StartCoroutine(WallDestroy());
                    messageName.text = "You";
                    messageText.text = "Well that did something.";
                    statusLauncherLvl3 = 2;
                }
                //exit message
                else if (statusLauncherLvl3 == 2 || statusLauncherLvl3 == 4)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeLauncherLvl3 = false;
                    statusLauncherLvl3 = 3;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //door 01 status
            if (active02)
            {
                //normal message exit
                if (status02 == 0)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    active02 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //boss door pass status
            if (active03)
            {
                //normal message exit
                if (status03 == 0)
                {
                    LevelManager.canPause = true;
                    print(LevelManager.canPause);
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    active03 = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
                else if (status03 == 1)
                {
                    messageName.text = "Overseer";
                    messageText.text = "You truly want to leave, don't you?";
                    status03 = 2;
                }
                else if (status03 == 2)
                {
                    messageName.text = "You";
                    messageText.text = "This is the exit, correct?";
                    status03 = 3;
                }
                else if (status03 == 3)
                {
                    messageName.text = "Overseer";
                    messageText.text = "Very well then...";
                    status03 = 4;
                }
                else if (status03 == 4)
                {
                    messageName.text = "";
                    messageText.text = "The intercom turns off.";
                    status03 = 5;
                }
                else if (status03 == 5)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    active03 = false;
                    DoorOpen();
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //boots status
            if (activeBoots)
            {
                //talk about boots
                if (statusBoots == 1)
                {
                    messageName.text = "You";
                    messageText.text = "Seems like these boots use battery.";
                    GetComponentInChildren<MeshRenderer>().enabled = false;
                    StartCoroutine(StatusBoots());
                }
                //normal message exit
                if (statusBoots == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    PlayerController.canJump = true;
                    equipmentPanel.SetActive(true);
                    player.GetComponent<PlayerController>().batteryJump = GameObject.FindGameObjectsWithTag("BatteryJump");
                    player.GetComponent<PlayerController>().batteryJumpMaxCharge = player.GetComponent<PlayerController>().batteryJump.Length;
                    player.GetComponent<PlayerController>().batteryJumpCurrentCharge = player.GetComponent<PlayerController>().batteryJumpMaxCharge;
                    Destroy(gameObject);
                }
            }
            //boots 2 status
            if (activeBoots2)
            {
                //normal message exit
                if (statusBoots2 == 1)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    PlayerController.doubleJumpActive = true;
                    Destroy(gameObject);
                }
            }
            //glove status
            if (activeGlove)
            {
                //talk about boots
                if (statusGlove == 1)
                {
                    messageName.text = "You";
                    messageText.text = "This glove uses battery as well.";
                    statusGlove = 2;
                }
                //normal message exit
                else if (statusGlove == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    PlayerController.canShoot = true;
                    gloveIcon.SetActive(true);
                    player.GetComponent<PlayerController>().batteryShoot = GameObject.FindGameObjectsWithTag("BatteryShoot");
                    player.GetComponent<PlayerController>().batteryShootMaxCharge = player.GetComponent<PlayerController>().batteryShoot.Length;
                    player.GetComponent<PlayerController>().batteryShootCurrentCharge = player.GetComponent<PlayerController>().batteryShootMaxCharge;
                    Destroy(gameObject);
                }
            }
            //tube status
            if (activeTube)
            {
                //normal message exit
                if (statusTube == 0)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    activeTube = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<CapsuleCollider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
            //keycard01 status
            if (activeKeycard01)
            {
                //normal message exit
                if (statusKeycard == 0)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    Destroy(gameObject);
                }
            }
            //keycard02 status
            if (activeKeycard02)
            {
                //normal message exit
                if (statusKeycard2 == 1)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    Destroy(gameObject);
                }
            }
            //keycard03 status
            if (activeKeycard03)
            {
                //normal message exit
                if (statusKeycard3 == 1)
                {
                    messageName.text = "You";
                    messageText.text = "Seems like this keycard has a barcode to scan with.";
                    statusKeycard3 = 2;
                }
                //normal message exit
                else if (statusKeycard3 == 2)
                {
                    LevelManager.canPause = true;
                    player.GetComponent<PlayerController>().enabled = true;
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    Destroy(gameObject);
                }
            }
            //eleavtor
            if (elevatorActive)
            {
                //normal message exit
                if (elevatorStatus == 0)
                {
                    LevelManager.canPause = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    LevelManager.canPause = true;
                    elevatorPanel.SetActive(false);
                    player.GetComponent<PlayerController>().enabled = true;
                    elevatorActive = false;
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<Level_01_Interact_Manager>().enabled = false;
                }
            }
        }
    }

    #endregion

    //when player presses F on object, this happens first
    #region
    public void StatusCheck()
    {
        GetComponent<Collider2D>().enabled = false;
        //crystal launcher
        if (name == "crystalReceptacle")
        {
            //no crystal picked up
            if (status01 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");

                messageText.text = "Some sort of pedestal. You notice something can be inserted on top.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                active01 = true;
            }
            //if player has crystal
            else if (status01 == 1)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gemplace");

                Destroy(GameObject.Find("crystal"));
                GameObject.Find("crystalInserted").GetComponent<MeshRenderer>().enabled = true;
                messageText.text = "You've inserted the Crystal. You hear something powered on.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                active01 = true;
                status02 = 1;
            }
            //after door opened
            else if (status01 == 2)
            {
                messageText.text = "The crystal turned on some sort of power.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                active01 = true;
            }
        }
        //lvl2 crystal launcher
        if (name == "crystalReceptaclelvl2")
        {
            //no crystal picked up
            if (statusCrystal2 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");

                messageName.text = "You";
                messageText.text = "Another one of those pedestals.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal2 = true;
            }
            //if player has crystal
            else if (statusCrystal2 == 1)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gemplace");

                Destroy(GameObject.Find("crystal2"));
                GameObject.Find("crystalInserted2").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("platformFloating (2)").GetComponent<Animation>().Play();
                messageText.text = "You've inserted the Crystal. You hear something powered on.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal2 = true;
                statusCrystal2 = 2;
            }
            //after inserted crystal
            else if (statusCrystal2 == 2)
            {
                messageName.text = "You";
                messageText.text = "That platform seems to be working now.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal2 = true;
            }
        }
        //lvl3 crystal launcher
        if (name == "crystalReceptaclelvl3")
        {
            //no crystal picked up
            if (statusCrystal3 == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");
                messageName.text = "You";
                messageText.text = "Need a crystal again.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal3 = true;
            }
            //if player has crystal
            else if (statusCrystal3 == 1)
            {
                Destroy(GameObject.Find("crystal3"));
                GameObject.Find("crystalInserted3").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("platformFloating (6)").GetComponent<Animation>().Play();
                messageText.text = "You've inserted the Crystal. You hear something powered on.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal3 = true;
                statusCrystal3 = 2;
            }
            //after inserted crystal
            else if (statusCrystal3 == 2)
            {
                messageName.text = "You";
                messageText.text = "How do these things actually work?";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal3 = true;
            }
        }
        //lvl3 crystal launcher 2
        if (name == "crystalReceptaclelvl3_02")
        {
            // initial message
            if (statusLauncherLvl3 == 0)
            {
                messageName.text = "You";
                messageText.text = "Huh, this one already has a crystal in it.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeLauncherLvl3 = true;
            }
            // button pressed
            else if (statusLauncherLvl3 == 3)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonsuccess");
                messageName.text = "You";
                messageText.text = "Seems like this turned off that wall over there.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeLauncherLvl3 = true;
                statusLauncherLvl3 = 4;
            }
        }
        //lvl3 crystal launcher 3
        if (name == "crystalReceptaclelvl3_03")
        {
            // initial message
            if (statusCrystal4 == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");
                messageName.text = "You";
                messageText.text = "Gotta find the crystal.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal4 = true;
            }
            // insert crystal
            else if (statusCrystal4 == 1)
            {
                Destroy(GameObject.Find("crystal4"));
                GameObject.Find("crystalInserted4").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("platformFloatinglvl3").GetComponent<Animation>().Play();
                messageText.text = "You've inserted the Crystal. You hear something powered on.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal4 = true;
                statusCrystal4 = 2;
            }
            // crystal inserted
            else if (statusCrystal4 == 2)
            {
                messageName.text = "You";
                messageText.text = "Got the platform working now.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeCrystal4 = true;
            }
        }
        //crystal
        else if (name == "crystal")
        {
            //if picked up change 01's status
            if (status01 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gempickup");

                status01 = 1;
            }
        }
        //crystal2
        else if (name == "crystal2")
        {
            //if picked up change 01's status
            if (statusCrystal2 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gempickup");

                statusCrystal2 = 1;
            }
        }
        //crystal3
        else if (name == "crystal3")
        {
            //if picked up change 01's status
            if (statusCrystal3 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gempickup");

                statusCrystal3 = 1;
            }
        }
        //crystal3
        else if (name == "crystal4")
        {
            //if picked up change 01's status
            if (statusCrystal4 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/gempickup");

                statusCrystal4 = 1;
            }
        }
        //pass scan
        else if (name == "passScan")
        {
            //if player doesn't have pass
            if (status03 == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");

                messageText.text = "It's a pass scanner.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                active03 = true;
            }
            else if (status03 == 1)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/overseerintro");
                messageText.text = "You hear an intercom turn on.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                active03 = true;
            }
        }
        //boots
        else if (name == "boots")
        {
            //when player picks up boots
            if (statusBoots == 0)
            {
                //play sound
                RuntimeManager.PlayOneShot("event:/Environment/powerup");

                messageText.text = "You found some Boots. You can now jump.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeBoots = true;
                player.GetComponent<PlayerController>().EnableBoots();
                PlayerController.footprintActive = false;
                GetComponentInChildren<MeshRenderer>().enabled = false;
                StartCoroutine(StatusBoots());
            }
        }
        //double jump boots
        else if (name == "doubleJumpBoots")
        {
            //when player picks up boots
            if (statusBoots2 == 0)
            {
                //play sound
                RuntimeManager.PlayOneShot("event:/Environment/powerup");

                messageText.text = "You found an upgrade for your boots. You can now double jump.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeBoots2 = true;
                GetComponentInChildren<MeshRenderer>().enabled = false;
                StartCoroutine(StatusBoots2());
            }
        }
        //glove
        else if (name == "glove")
        {
            //when player picks up boots
            if (statusGlove == 0)
            {
                //play sound
                RuntimeManager.PlayOneShot("event:/Environment/powerup");

                messageText.text = "You found a power glove. You can now shoot power orbs.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeGlove = true;
                player.GetComponent<PlayerController>().EnableGlove();
                PlayerController.canShoot = true;
                GetComponentInChildren<MeshRenderer>().enabled = false;
                statusGlove = 1;
                //StartCoroutine(StatusBoots());
            }
        }
        //test tube
        else if (name == "Test_Tube_01")
        {
            //when player interacts with test tube
            if (statusTube == 0)
            {
                messageName.text = "You";
                messageText.text = "Why am I here..?";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                GetComponent<CapsuleCollider2D>().enabled = false;
                activeTube = true;
            }
        }
        //keycard01
        else if (name == "keycard01")
        {
            //when player picks up keycard
            if (statusKeycard == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/passpickup");
                messageText.text = "You found a keycard that allows access to Floor 02.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                activeKeycard01 = true;
                level2Access = true;
            }
        }
        //keycard02
        else if (name == "keycard02")
        {
            //when player picks up keycard
            if (statusKeycard2 == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/passpickup");
                activeKeycard02 = true;
                StartCoroutine(StatusKeycard2());
                level3Access = true;
                messageText.text = "You found a keycard that allows access to Floor 01.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            }
        }
        //keycard03
        else if (name == "keycard03")
        {
            //when player picks up keycard
            if (statusKeycard3 == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/passpickup");
                activeKeycard03 = true;
                StartCoroutine(StatusKeycard3());
                level4Access = true;
                status03 = 1;
                messageText.text = "You found a keycard that allows access to Floor 00.";
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            }
        }
        //door buttons
        else if (CompareTag("DoorButton"))
        {
            LevelManager.canPause = true;
            //door button 01
            if (name == "door01Button")
            {
                //if crystal hasn't been inserted
                if (status02 == 0)
                {
                    // play sound
                    RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonfail");

                    messageText.text = "You press the button. There seems to be no power running.";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                    active02 = true;
                }
                else if (status02 == 1)
                {
                    // play sound
                    RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonsuccess");

                    player.GetComponent<PlayerController>().enabled = true;
                    GetComponent<Collider2D>().enabled = false;
                    DoorOpen();
                }
            }
            //any non-specific door button
            else
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonsuccess");

                player.GetComponent<PlayerController>().enabled = true;
                GetComponent<Collider2D>().enabled = false;
                DoorOpen();
            }
        }
        //elevator buttons
        else if (CompareTag("ElevatorButton"))
        {
            //open elevator panel choices
            if (elevatorStatus == 0)
            {
                // play sound
                RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorbuttonsuccess");

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                LevelManager.canPause = false;
                player.GetComponent<PlayerController>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                elevatorPanel.SetActive(true);
                elevatorActive = true;
            }
            //enter elevator after making choice
            else if (elevatorStatus == 1)
            {
                customEnterSpotElevator = true;
                DoorEnter();
            }
        }
        //door enter
        else if (CompareTag("Door"))
        {
            if (name == "floor02door02")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotBoots").transform.position;
                customEnterSpot = true;
                camSpot = camera.transform.position;
                camSpotNew = GameObject.Find("camSpotBoots").transform.position;
                StartCoroutine(DirectionalLightOff());
            }
            else if (name == "bootsRoomDoor")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotf01d02").transform.position;
                customEnterSpot = true;
                camSpotNew = camSpot;
                StartCoroutine(DirectionalLightOn());
            }
            else if (name == "lvl2DoorCard")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotCard").transform.position;
                customEnterSpot = true;
                camSpot = camera.transform.position;
                camSpotNew = GameObject.Find("camSpotBoots").transform.position;
                StartCoroutine(DirectionalLightOn());
            }
            else if (name == "doorKeycard")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotCard2").transform.position;
                customEnterSpot = true;
                camSpot = camera.transform.position;
                camSpotNew = GameObject.Find("camSpotBoots").transform.position;
                StartCoroutine(DirectionalLightOn());
            }
            else if (name == "cardRoomDoor")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotlvl2Card").transform.position;
                customEnterSpot = true;
                camSpotNew = camSpot;
                StartCoroutine(DirectionalLightOn());
            }
            else if (name == "cardRoomDoor2")
            {
                doorEnterSpotNextCustom = GameObject.Find("enterSpotlvl3Card").transform.position;
                customEnterSpot = true;
                camSpotNew = camSpot;
                StartCoroutine(DirectionalLightOn());
            }
            DoorEnter();
        }
    }
    #endregion

    //door code
    #region
    public void DoorOpen()
    {
        // play door open sound
        RuntimeManager.PlayOneShot("event:/Environment/Interactables/dooropen");

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject obj in objectsWithTag)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) <= Vector3.Distance(player.transform.position, closestDoor.transform.position))
            {
                closestDoor = obj;
            }
        }
        if (doorEntered)
        {
            if (closestDoor.name == "finalBossDoorEnter")
            {
                closestDoor.GetComponent<Animator>().Play("BossDoorOpen");
                StartCoroutine(DoorExit());
            }
            else
            {
                closestDoor.GetComponent<Animator>().Play("SlidingUpDoorOpen");
                StartCoroutine(DoorExit());
            }
        }
        else
        {
            if (closestDoor.name == "finalBossDoor")
            {
                closestDoor.GetComponent<Animator>().Play("BossDoorOpen");
            }
            else
            {
                closestDoor.GetComponent<Animator>().Play("SlidingUpDoorOpen");
            }
            if (!elevatorButtonPressed)
            {
                closestDoor.GetComponent<Collider2D>().enabled = true;
            }
        }
        //Debug.Log(closestDoor);
    }


    void DoorEnter()
    {
        
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("DoorEnterSpot");
        //disable player movement
        player.GetComponent<PlayerController>().enabled = false;
        //disable door triggers
        GetComponent<Collider2D>().enabled = false;
        //find closest door
        foreach (GameObject obj in objectsWithTag)
        {
            if(Vector3.Distance(player.transform.position, obj.transform.position) <= Vector3.Distance(player.transform.position, closestEnterSpot.transform.position))
            {
                closestEnterSpot = obj;
            }
        }
        if (closestEnterSpot.name == "enterSpotBoss")
        {
            bossDoorEntered = true;
        }
        //set next door spot
        for (int i = 0; i < objectsWithTag.Length; i++)
        {
            if (objectsWithTag[i].name == closestEnterSpot.name && objectsWithTag[i].transform.parent.name != closestEnterSpot.transform.parent.name)
            {
                doorEnterSpotNext = objectsWithTag[i].transform.position;
                break;
            }
        }
        //Debug.Log(doorEnterSpotNext);
        player.transform.position = closestEnterSpot.transform.position;
        doorEntered = true;
        StartCoroutine(DoorClose(0.5f));
    }

    IEnumerator DoorExit()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("DoorExitSpot");
        GameObject[] doorButtons = GameObject.FindGameObjectsWithTag("DoorButton");
        GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
        yield return new WaitForSeconds(1);
        foreach (GameObject obj in objectsWithTag)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) <= Vector3.Distance(player.transform.position, closestExitSpot.transform.position))
            {
                closestExitSpot = obj;
            }
        }
        foreach (GameObject button in doorButtons)
        {
            button.GetComponent<Collider2D>().enabled = true;
        }
        foreach (GameObject button in elevatorButtons)
        {
            button.GetComponent<Collider2D>().enabled = true;
            button.GetComponent<Level_01_Interact_Manager>().enabled = false;
        }
        doorEntered = false;
        if (elevatorButtonPressed)
        {
            //player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y, -player.transform.localScale.z);
            elevatorButtonPressed = false;
        }
        LevelManager.canPause = true;
        player.transform.position = closestExitSpot.transform.position;
        elevatorStatus = 0;
        StartCoroutine(DoorClose(0));
    }

    IEnumerator DoorClose(float closeTime)
    {
        yield return new WaitForSeconds(closeTime);
        if (doorEntered && customEnterSpot)
        {
            GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
        }
        if (elevatorActive && SceneManager.GetActiveScene().name != "scLevel1")
        {
            if (floor == 4 || floor == 5)
            GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
            StartCoroutine(ToLevel1());
        }
        if (floor == 3 && elevatorActive && SceneManager.GetActiveScene().name != "scLevel2")
        {
            GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
            StartCoroutine(ToLevel2());
        }
        if (floor == 2 && elevatorActive && SceneManager.GetActiveScene().name != "scLevel3")
        {
            GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
            StartCoroutine(ToLevel3());
        }
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Door");
        //Debug.Log("Before: " + closestDoor);
        foreach (GameObject obj in objectsWithTag)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) <= Vector3.Distance(player.transform.position, closestDoor.transform.position))
            {
                closestDoor = obj;
            }
        }
        if (closestDoor.name == "finalBossDoor")
        {
            yield return new WaitForSeconds(1);
            closestDoor.GetComponent<Animator>().SetTrigger("CloseDoor");
            yield return new WaitForSeconds(1);
            GameObject.Find("Fade").GetComponent<Animation>().Play("FadeOut");
            StartCoroutine(ToBoss());
        }
        else if (closestDoor.name == "finalBossDoorEnter")
        {
            yield return new WaitForSeconds(1);
            closestDoor.GetComponent<Animator>().SetTrigger("CloseDoor");
        }
        else
        {
            closestDoor.GetComponent<Animator>().SetTrigger("CloseDoor");
        }
        closestDoor.GetComponent<Animator>().SetTrigger("CloseDoor");

        // play door open sound
        RuntimeManager.PlayOneShot("event:/Environment/Interactables/doorclose");

        yield return new WaitForSeconds(1);
        if (doorEntered)
        {
            yield return new WaitForSeconds(1);
            if (customEnterSpot)
            {
                player.transform.position = doorEnterSpotNextCustom;
                camera.transform.position = camSpotNew;
                GameObject.Find("Fade").GetComponent<Animation>().Play("FadeIn");
                customEnterSpot = false;
            }
            else if (customEnterSpotElevator)
            {
                player.transform.position = elevatorEnterSpot;
                customEnterSpotElevator = false;
                elevatorActive = false;
            }
            else
            {
                player.transform.position = doorEnterSpotNext;
            }
            DoorOpen();
        }
        else if (exitEnablePlayer == false)
        {
            player.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
    #endregion

    //elevator code
    #region

    public void Floor4A()
    {
        if (floor == 5)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 5;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            LevelManager.canPause = true;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            if (SceneManager.GetActiveScene().name == "scLevel1")
            {
                elevatorEnterSpot = GameObject.Find("enterSpotf02e01").transform.position;
            }
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    public void Floor4B()
    {
        if (floor == 4)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 4;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            LevelManager.canPause = true;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            if (SceneManager.GetActiveScene().name == "scLevel1")
            {
                elevatorEnterSpot = GameObject.Find("enterSpotf01e01").transform.position;
            }
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    public void Floor3()
    {
        if (floor == 3)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else if (!level2Access)
        {
            messageText.text = "It seems you need a keycard to access this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 3;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            LevelManager.canPause = true;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            //elevatorEnterSpot = GameObject.Find("enterSpotf01e01").transform.position;
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    public void Floor2()
    {
        if (floor == 2)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else if (!level3Access)
        {
            messageText.text = "It seems you need a keycard to access this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 2;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            LevelManager.canPause = true;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            //elevatorEnterSpot = GameObject.Find("enterSpotf01e01").transform.position;
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    public void Floor1()
    {
        if (floor == 1)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else if (!level4Access)
        {
            messageText.text = "It seems you need a keycard to access this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 1;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            elevatorEnterSpot = GameObject.Find("enterSpotf01e01").transform.position;
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    public void Floor0()
    {
        if (floor == 0)
        {
            messageText.text = "You're already on this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else if (!level5Access)
        {
            messageText.text = "It seems you need a keycard to access this floor.";
            messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            StopCoroutine("MessageOff");
            StartCoroutine("MessageOff");
        }
        else
        {
            floor = 0;
            elevatorPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            elevatorEnterSpot = GameObject.Find("enterSpotf01e01").transform.position;
            GameObject[] elevatorButtons = GameObject.FindGameObjectsWithTag("ElevatorButton");
            foreach (GameObject button in elevatorButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
                button.GetComponent<Level_01_Interact_Manager>().enabled = false;
            }
            elevatorStatus = 1;
            elevatorButtonPressed = true;
            DoorOpen();
        }
    }

    #endregion

    //coroutines/functions
    #region
    IEnumerator DirectionalLightOff()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0;
    }

    IEnumerator DirectionalLightOn()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0.3f;
    }

    IEnumerator MessageOff()
    {
        yield return new WaitForSeconds(2);
        messageText.text = "";
        messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    IEnumerator StatusBoots()
    {
        yield return new WaitForSeconds(0.1f);
        statusBoots += 1;
    }

    IEnumerator StatusBoots2()
    {
        yield return new WaitForSeconds(0.1f);
        statusBoots2 += 1;
    }

    IEnumerator StatusKeycard2()
    {
        yield return new WaitForSeconds(0.1f);
        statusKeycard2 += 1;
    }

    IEnumerator StatusKeycard3()
    {
        yield return new WaitForSeconds(0.1f);
        statusKeycard3 += 1;
    }

    IEnumerator ToLevel1()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("scLevel1");
    }

    IEnumerator ToLevel2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("scLevel2");
    }

    IEnumerator ToLevel3()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("scLevel3");
    }

    IEnumerator ToBoss()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("scLevel4");
    }

    IEnumerator WallDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(GameObject.Find("forceWallRed"));
    }

    public void DoorEntered()
    {
        doorEntered = true;
    }

    public static void Reset()
    {
        level2Access = false;
        level3Access = false;
        level4Access = false;
        level5Access = false;
        floor = 5;
        doorEnterStatus = 0;
        elevatorStatus = 0;
        status01 = 0;
        status02 = 0;
        status03 = 0;
        statusBoots = 0;
        statusTube = 0;
        statusKeycard = 0;
        statusKeycard2 = 0;
        statusKeycard3 = 0;
        statusBoots2 = 0;
        statusCrystal2 = 0;
        statusCrystal3 = 0;
        statusLauncherLvl3 = 0;
        statusCrystal4 = 0;
        statusGlove = 0;
    }

    #endregion
}
