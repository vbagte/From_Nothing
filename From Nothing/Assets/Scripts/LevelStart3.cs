using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart3 : MonoBehaviour
{
    public static bool levelEntered = false;

    public GameObject player;
    public GameObject fade;
    public GameObject dialogue;
    public GameObject platform;
    public GameObject keycard;
    public GameObject crystal;
    public GameObject crystalInserted;
    public GameObject boots;
    public GameObject gloveIcon;
    public GameObject pauseScript;

    private void Awake()
    {
        LevelManager.canPause = false;
        fade.GetComponent<Animation>().Play("FadeIn");
        PlayerController.canJump = true;
        PlayerController.doubleJumpActive = true;
        PlayerController.footprintActive = false;
        StartCoroutine(DoorOpen());
        GameObject.Find("doorEnter").GetComponent<Level_01_Interact_Manager>().exitEnablePlayer = false;
        if (levelEntered)
        {
            pauseScript.SetActive(true);
            GameObject.Find("doorEnter").GetComponent<Level_01_Interact_Manager>().exitEnablePlayer = true;
            dialogue.SetActive(false);
            if (Level_01_Interact_Manager.statusCrystal3 >= 2)
            {
                GameObject.Find("crystalInserted3").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("platformFloating (6)").GetComponent<Animation>().Play();
            }
            if (Level_01_Interact_Manager.statusGlove >= 1)
            {
                Destroy(GameObject.Find("glove"));
            }
            if (Level_01_Interact_Manager.statusLauncherLvl3 >= 3)
            {
                Destroy(GameObject.Find("forceWallRed"));
                Destroy(GameObject.Find("crystal3"));
                GameObject.Find("SceneSwitchLvl3_02").GetComponent<Collider2D>().enabled = true;
            }
            if (Level_01_Interact_Manager.statusCrystal4 >= 2)
            {
                GameObject.Find("crystalInserted4").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("platformFloatinglvl3").GetComponent<Animation>().Play();
            }
            if (Level_01_Interact_Manager.statusKeycard3 >= 1)
            {
                Destroy(GameObject.Find("keycard03"));
            }
            if (PlayerController.canShoot)
            {
                gloveIcon.SetActive(true);
            }
            SlimeStation.enemySpawns = 0;
            Enemy_02_movement.slimeDead = 0;
        }
    }

    private void Start()
    {
        levelEntered = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("doorEnter").GetComponent<Level_01_Interact_Manager>().DoorEntered();
        GameObject.Find("doorEnter").GetComponent<Level_01_Interact_Manager>().DoorOpen();
    }
}
