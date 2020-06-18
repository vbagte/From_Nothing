using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01Dialogue : MonoBehaviour
{

    public GameObject player;
    public GameObject fade;
    public GameObject messagePanel;
    public Text messageName;
    public Text messageText;

    private bool dialogueActive = false;
    private int dialogueStatus;

    private void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        fade.GetComponent<Animation>().Play("FadeIn");
        StartCoroutine(DialogueStart());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogueActive)
        {
            if (dialogueStatus == 0)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerintro");
                messageName.text = "";
                messageText.text = "You hear an intercom turn on.";
                dialogueStatus = 1;
            }
            else if (dialogueStatus == 1)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                messageName.text = "Overseer";
                messageText.text = "I see you're awake.";
                dialogueStatus = 2;
            }
            else if (dialogueStatus == 2)
            {
                messageName.text = "You";
                messageText.text = "Who are you? Where are you?? Tell me what's going on!";
                dialogueStatus = 3;
            }
            else if (dialogueStatus == 3)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                messageName.text = "Overseer";
                messageText.text = "You'll find out soon enough.";
                dialogueStatus = 4;
            }
            else if (dialogueStatus == 4)
            {
                RuntimeManager.PlayOneShot("event:/Environment/overseerhangup");
                messageName.text = "";
                messageText.text = "The intercom turns off.";
                dialogueStatus = 5;
            }
            else if (dialogueStatus == 5)
            {
                messageName.text = "You";
                messageText.text = "I need to get out of here.";
                dialogueStatus = 6;
            }
            else if (dialogueStatus == 6)
            {
                messageName.text = "";
                messageText.text = "";
                LevelManager.canPause = true;
                messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                player.GetComponent<PlayerController>().enabled = true;
                dialogueStatus = 7;
            }
        }
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        dialogueActive = true;
        messageName.text = "You";
        messageText.text = "Where am I? Why am I invisible??";
        messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
    }



}
