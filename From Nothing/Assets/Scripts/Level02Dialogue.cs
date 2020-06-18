using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class Level02Dialogue : MonoBehaviour
{

    public GameObject player;
    public GameObject messagePanel;
    public GameObject pauseScript;
    public Text messageName;
    public Text messageText;

    private bool dialogueActive = false;
    private int dialogueStatus;

    private void Start()
    {
        StartCoroutine(DialogueStart());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogueActive)
        {
            if (dialogueStatus == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                messageName.text = "Overseer";
                messageText.text = "Are you trying to leave?";
                dialogueStatus = 1;
            }
            else if (dialogueStatus == 1)
            {
                messageName.text = "You";
                messageText.text = "Tell me what's going on!";
                dialogueStatus = 2;
            }
            else if (dialogueStatus == 2)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                messageName.text = "Overseer";
                messageText.text = "You'll never leave.";
                dialogueStatus = 3;
            }
            else if (dialogueStatus == 3)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerhangup");
                messageName.text = "";
                messageText.text = "The intercom turns off.";
                dialogueStatus = 4;
            }
            else if (dialogueStatus == 4)
            {
                messageName.text = "You";
                messageText.text = "I'm finding a way out...";
                dialogueStatus = 5;
            }
            else if (dialogueStatus == 5)
            {
                messageName.text = "";
                messageText.text = "";
                LevelManager.canPause = true;
                pauseScript.SetActive(true);
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                player.GetComponent<PlayerController>().enabled = true;
                dialogueStatus = 6;
            }
        }
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(3);
        RuntimeManager.PlayOneShot("event:/Environment/overseerintro");
        dialogueActive = true;
        messageName.text = "";
        messageText.text = "You hear an intercom turn on.";
        messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
    }



}
