using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class BossDead : MonoBehaviour
{
    public GameObject player;
    public GameObject fade;
    public GameObject messagePanel;
    public GameObject pauseScript;
    public GameObject endText;
    public Text messageName;
    public Text messageText;

    private bool dialogueActive;
    private int dialogueStatus;
    private bool endActive;
    private int endStatus;

    FMOD.Studio.EventInstance music;
    IEnumerator Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/levelbgm");
        music.start();
        RuntimeManager.PlayOneShot("event:/Environment/overseerintro");

        LevelManager.canPause = false;
        pauseScript.SetActive(false);
        yield return new WaitForSeconds(2);
        dialogueActive = true;
        messageName.text = "";
        messageText.text = "You hear an intercom turn on.";
        messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dialogueActive)
            {
                if (dialogueStatus == 0)
                {
                    messageName.text = "Overseer";
                    messageText.text = "...";
                    dialogueStatus = 1;
                }
                else if (dialogueStatus == 1)
                {
                    RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                    messageName.text = "Overseer";
                    messageText.text = "You're sure you want to leave?";
                    dialogueStatus = 2;
                }
                else if (dialogueStatus == 2)
                {
                    messageName.text = "You";
                    messageText.text = "Are you finally letting me go?";
                    dialogueStatus = 3;
                }
                else if (dialogueStatus == 3)
                {
                    RuntimeManager.PlayOneShot("event:/Environment/overseerloop");
                    messageName.text = "Overseer";
                    messageText.text = "Very well, let me show you the exit.";
                    dialogueStatus = 4;
                }
                else if (dialogueStatus == 4)
                {
                    
                    messageName.text = "";
                    messageText.text = "";
                    messagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    fade.GetComponent<Animation>().Play("FadeOut");
                    StartCoroutine(EndActive("The Overseer showed you the way out. " +
                        "Feeling relieved, you start walking towards the exit. You have thoughts " +
                        "of what just happened and where you will go from here. You finally reach " +
                        "the exit and take your first step outside the facility. However, one look " +
                        "of the outside, and you realize the world is nothing like you remembered it..."));
                    dialogueStatus = 5;
                    dialogueActive = false;
                }
            }
            if (endActive)
            {
                if (endStatus == 0)
                {
                    endText.GetComponent<Animation>().Play("EndTextFadeOut");
                    StartCoroutine(EndActive("Created and developed by:\n" +
                        "The EDCC CS185 2020 Team"));
                    endStatus = 1;
                    endActive = false;
                }
                else if (endStatus == 1)
                {
                    RuntimeManager.PlayOneShot("event:/Environment/overseerhangup");
                    music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    music.release();

                    endText.GetComponent<Animation>().Play("EndTextFadeOut");
                    StartCoroutine(EndActive("Thanks for playing!"));
                    endStatus = 2;
                    endActive = false;
                }
                else if (endStatus == 2)
                {
                    endText.GetComponent<Animation>().Play("EndTextFadeOut");
                    StartCoroutine(MainMenu());
                    endStatus = 1;
                    endActive = false;
                }
            }
        }
    }

    IEnumerator EndActive(string text)
    {
        yield return new WaitForSeconds(2);
        endText.GetComponent<Text>().text = text;
        endText.GetComponent<Animation>().Play("EndTextFadeIn");
        yield return new WaitForSeconds(2);
        endActive = true;
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("scMainMenu");
    }

}
