using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart2 : MonoBehaviour
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
        PlayerController.footprintActive = false;
        StartCoroutine(DoorOpen());
        GameObject.Find("door01").GetComponent<Level_01_Interact_Manager>().exitEnablePlayer = false;
        if (levelEntered)
        {
            pauseScript.SetActive(true);
            GameObject.Find("door01").GetComponent<Level_01_Interact_Manager>().exitEnablePlayer = true;
            dialogue.SetActive(false);
            if (Level_01_Interact_Manager.statusCrystal2 == 2)
            {
                platform.GetComponent<Animation>().Play();
                crystal.SetActive(false);
                crystalInserted.GetComponent<MeshRenderer>().enabled = true;
            }
            if (Level_01_Interact_Manager.statusKeycard2 == 1)
            {
                keycard.SetActive(false);
            }
            if (Level_01_Interact_Manager.statusBoots2 == 1)
            {
                PlayerController.doubleJumpActive = true;
                player.GetComponent<PlayerController>().canJumpDouble = true;
                boots.SetActive(false);
            }
            if (PlayerController.canShoot)
            {
                gloveIcon.SetActive(true);
            }
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
        GameObject.Find("door01").GetComponent<Level_01_Interact_Manager>().DoorEntered();
        GameObject.Find("door01").GetComponent<Level_01_Interact_Manager>().DoorOpen();
    }
}
