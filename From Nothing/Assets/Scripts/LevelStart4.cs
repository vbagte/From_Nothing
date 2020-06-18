using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart4 : MonoBehaviour
{
    public static bool levelEntered = false;

    public GameObject player;
    public GameObject playerHealth;
    public GameObject fade;
    public GameObject dialogue;
    public GameObject boss;
    public GameObject bossBattery;
    public GameObject pauseScript;

    private void Awake()
    {
        PlayerController.canJump = true;
        PlayerController.doubleJumpActive = true;
        PlayerController.footprintActive = false;
        PlayerController.canShoot = true;
        player.GetComponent<PlayerController>().canJumpDouble = true;        
        if (levelEntered)
        {
            pauseScript.SetActive(true);
            LevelManager.canPause = true;
            Chimera.bossStop = false;
            bossBattery.SetActive(true);
            playerHealth.GetComponent<Animation>().Play();
            Vector3 pos = new Vector3(0, 0, 0);
            player.transform.position = pos;
            player.GetComponent<PlayerController>().enabled = true;
            fade.GetComponent<Animation>().Play("FadeIn");
            dialogue.SetActive(false);
            boss.GetComponent<Chimera>().enabled = true;
            StartCoroutine(Platforms());
            LevelManager.canPause = true;
        }
        else
        {
            LevelManager.canPause = false;
            fade.GetComponent<Animation>().Play("FadeIn");
            StartCoroutine(DoorOpen());
            GameObject.Find("finalBossDoorEnter").GetComponent<Level_01_Interact_Manager>().exitEnablePlayer = false;
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
        GameObject.Find("finalBossDoorEnter").GetComponent<Level_01_Interact_Manager>().DoorEntered();
        GameObject.Find("finalBossDoorEnter").GetComponent<Level_01_Interact_Manager>().DoorOpen();
    }

    IEnumerator Platforms()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("platformFloating (2)").GetComponent<UpDown>().enabled = true;
        GameObject.Find("platformFloating (3)").GetComponent<UpDown>().enabled = true;
    }

}
