using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart1 : MonoBehaviour
{

    public static bool level1Entered = false;

    public GameObject player;
    public GameObject fade;
    public GameObject dialogue;
    public GameObject equipmentPanel;
    public GameObject camera;
    public GameObject crystal;
    public GameObject crystalInserted;
    public GameObject boots;
    public GameObject gloveIcon;
    public GameObject keycard;
    public GameObject sceneSwitch;
    public GameObject floor5Door;
    public GameObject floor4Door;

    private void Awake()
    {
        PlayerController.canJump = false;
        PlayerController.footprintActive = true;
        LevelManager.canPause = false;
        if (level1Entered)
        {
            dialogue.SetActive(false);
            keycard.SetActive(false);
            equipmentPanel.SetActive(true);            
            PlayerController.canJump = true;
            PlayerController.footprintActive = false;
            player.GetComponent<PlayerController>().batteryJumpCurrentCharge = 5;
            player.GetComponent<PlayerController>().enabled = false;
            fade.GetComponent<Animation>().Play("FadeIn");
            Vector3 newCamPos = new Vector3(18, 0.86f, -10.96f);
            camera.transform.position = newCamPos;
            Level_01_Interact_Manager.status01 = 2;
            Level_01_Interact_Manager.status02 = 1;
            crystal.SetActive(false);
            crystalInserted.GetComponent<MeshRenderer>().enabled = true;
            boots.SetActive(false);
            Vector3 newSwitchPos = new Vector3(sceneSwitch.transform.position.x - 1.5f, sceneSwitch.transform.position.y, sceneSwitch.transform.position.z);
            sceneSwitch.transform.position = newSwitchPos;
            sceneSwitch.GetComponent<SceneSwitch>().status = 1;
            if (Level_01_Interact_Manager.floor == 5)
            {
                Vector3 newPlayerPos = new Vector3(30.26f, 0.27f, -1);
                player.transform.position = newPlayerPos;
                StartCoroutine(DoorOpen());
            }
            else if (Level_01_Interact_Manager.floor == 4)
            {
                Vector3 newPlayerPos = new Vector3(30.26f, -4.64f, -1);
                player.transform.position = newPlayerPos;
                StartCoroutine(DoorOpen());
            }
            if (PlayerController.canShoot)
            {
                gloveIcon.SetActive(true);
            }
        }
    }

    private void Start()
    {
        level1Entered = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(2);
        if (Level_01_Interact_Manager.floor == 5)
        {
            floor5Door.GetComponent<Level_01_Interact_Manager>().enabled = true;
            floor5Door.GetComponent<Level_01_Interact_Manager>().DoorEntered();
            floor5Door.GetComponent<Level_01_Interact_Manager>().DoorOpen();
        }
        else if (Level_01_Interact_Manager.floor == 4)
        {
            floor4Door.GetComponent<Level_01_Interact_Manager>().enabled = true;
            floor4Door.GetComponent<Level_01_Interact_Manager>().DoorEntered();
            floor4Door.GetComponent<Level_01_Interact_Manager>().DoorOpen();
        }
    }

}
