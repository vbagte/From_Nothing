/* Taylor Koonce 
 * April-June 2020
 * Load Scene Manager is needed for the statr menu 
 * Scenes that can lead to different scenes such as settings
 * or the beginning of the game. Also used for quitting
 * Can be used again for loading other scenes. Best used with
 * hit boxes/colliders.
 * Video: https://www.youtube.com/watch?v=Oadq-IrOazg
 */
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public static bool canPause;
    public bool iCanPause;

    public string SceneToLoad;//variable name that will be the name of the next scene
    public string settings;//variable name to go to the settings
    //public Animator animator; //access the animator
    int count = 1; //Counter for how many times escape is pressed. Must be set to 1. Code checks for odd or even counts
    public GameObject PauseMenu; //variable for the pause menu game object
    public GameObject player;  //Variable for the player to disable movement
    public GameObject fade; //fade panel
    private FMOD.Studio.Bus musicBus;

    private void Start()
    {
        GetComponent<Animation>().Play("FadeToClear");//Animation between scenes
        if (PauseMenu == null)
        {
            PauseMenu = GameObject.Find("objPauseMenu");//Pause Menu to be able to show it and hide it
        }
        PauseMenu.SetActive(false);
        player = GameObject.Find("Player");
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
    }

    //Checks for input so often
    private void Update()
    {
        //Check pause status
        iCanPause = canPause;
        //Check to see if the escape key has been pressed. MUST BE KEY DOWN
        if (Input.GetKeyDown("escape") && canPause)
        {
            count++;//Add one to the counter to check to see how many times the escape is pressed

            //If the count is even then activate the menu, disable player movement
            if (count % 2 == 0)
            {
                musicBus.setPaused(true);
                Interactable.canInteractS = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<PlayerController>().enabled = false;//Disable player movement
                PauseMenu.SetActive(true);
                Time.timeScale = 0; // stop time
            }
            //Else If the count is odd then, deactivate the menu, activate player movement
            else
            {
                musicBus.setPaused(false);
                Interactable.canInteractS = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<PlayerController>().enabled = true;//Enable player movement
                PauseMenu.SetActive(false);
                Time.timeScale = 1; // resume time
            }
        }
    }

    //Gets the level that is to be loaded and fades from the current screen to the next level
    public void FadeToLevel(string scene)
    {
        //Gets the name of the scene that needs to be loaded in next
        SceneToLoad = scene;
        //Set the animation trigger to true
        //animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    //Loads the first level
    public void LoadGame(string scene)
    {
        //Calls Unity Scene manger to load the specific scene
        //animator.SetTrigger("FadeOut");
        StartCoroutine(anim(scene));

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("scMainMenu");
    }

    IEnumerator anim(string scene)
    {
        fade.SetActive(true);
        //fade.GetComponent<Animator>().Play("FadeToBlack");
        yield return new WaitForSeconds(1);
        //reset game values
        Level_01_Interact_Manager.Reset();
        LevelStart1.level1Entered = false;
        LevelStart2.levelEntered = false;
        LevelStart3.levelEntered = false;
        //load main menu
        SceneManager.LoadScene(scene);
    }

    //Load the settings option in the main menu. 
    public void LoadSettings(string settings)
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(settings);
    }

    //Exits the game for the main start menu
    public void QuitGame()
    {
        //For testing that the game closes while testing in the editor
        Debug.Log("Game Exited");
        //Kills the program
        Application.Quit();
    }

}
