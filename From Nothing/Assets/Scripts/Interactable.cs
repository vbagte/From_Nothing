using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
public class Interactable : MonoBehaviour
{
    public static bool canInteractS = true;

    private GameObject player;
    private GameObject pickupSpot;
    private GameObject interactPanel;
    private Text interactText;
    private bool canPickup;
    private bool canInteract;

    private void Start()
    {
        player = GameObject.Find("Player");
        pickupSpot = GameObject.Find("PickupSpot");
        interactPanel = GameObject.Find("InteractPanel");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canInteractS)
        {
            if (canPickup)
            {
                transform.parent = pickupSpot.transform;
                transform.localPosition = new Vector3(0, 0, 0);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Level_01_Interact_Manager>().enabled = true;
                GetComponent<Level_01_Interact_Manager>().StatusCheck();
            }
            else if (canInteract)
            {
                LevelManager.canPause = false;
                player.GetComponent<PlayerController>().enabled = false;
                interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                interactText.color = new Color(255, 255, 255, 0);
                GetComponent<Level_01_Interact_Manager>().enabled = true;
                GetComponent<Level_01_Interact_Manager>().StatusCheck();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Pickup") && other.CompareTag("Player"))
        {
            RuntimeManager.PlayOneShot("event:/Environment/interact");
            interactText.text = "Press F to pick up";
            interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
            interactText.color = new Color(255, 255, 255, 1);
            canPickup = true;
        }
        else if (CompareTag("Door") && other.CompareTag("Player") || CompareTag("ElevatorButton") && Level_01_Interact_Manager.elevatorButtonPressed)
        {
            RuntimeManager.PlayOneShot("event:/Environment/interact");
            interactText.text = "Press F to enter";
            interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
            interactText.color = new Color(255, 255, 255, 1);
            canInteract = true;
        }
        else if (other.CompareTag("Player"))
        {
            RuntimeManager.PlayOneShot("event:/Environment/interact");
            interactText.text = "Press F to interact";
            interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
            interactText.color = new Color(255, 255, 255, 1);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (CompareTag("Pickup") && other.CompareTag("Player"))
        {
            interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            interactText.color = new Color(255, 255, 255, 0);
            canPickup = false;
        }
        else if (other.CompareTag("Player"))
        {
            interactPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            interactText.color = new Color(255, 255, 255, 0);
            canInteract = false;
        }
    }

    //fade code
    //IEnumerator FadeIn()
    //{
    //    for (float i = iPanelColorCurrent.a; i < 0.3f; i+=0.05f)
    //    {
    //        iPanelColorCurrent.a = i;
    //        interactPanel.GetComponent<Image>().color = iPanelColorCurrent;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}

    //IEnumerator FadeInText()
    //{
    //    for (float i = iTextColorCurrent.a; i < 1; i += 0.05f)
    //    {
    //        iTextColorCurrent.a = i;
    //        interactText.color = iTextColorCurrent;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}

    //IEnumerator FadeOut()
    //{
    //    for (float i = iPanelColorCurrent.a; i > 0; i -= 0.05f)
    //    {
    //        iPanelColorCurrent.a = i;
    //        interactPanel.GetComponent<Image>().color = iPanelColorCurrent;
    //        yield return new WaitForSeconds(0.05f);
    //    }        
    //}

    //IEnumerator FadeOutText()
    //{
    //    for (float i = iTextColorCurrent.a; i > 0; i -= 0.05f)
    //    {
    //        iTextColorCurrent.a = i;
    //        interactText.color = iTextColorCurrent;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}


}
