using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{

    public GameObject camera;
    public float camMove;
    public float camSpeed;
    public float triggerMove;

    private bool cameraMove = false;
    private float camXStart;
    private bool lvl3Triggered = false;

    public int status;

    private void Update()
    {
        if (cameraMove)
        {
            if (status == 0)
            {
                if (name == "SceneSwitchLvl3_02")
                {
                    if (camera.transform.position.x > camXStart - camMove)
                    {
                        camera.transform.Translate(-camSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        LevelManager.canPause = true;
                        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                        status = 1;
                        cameraMove = false;
                    }
                }
                else
                {
                    if (camera.transform.position.x < camXStart + camMove)
                    {
                        camera.transform.Translate(camSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        LevelManager.canPause = true;
                        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                        status = 1;
                        cameraMove = false;
                    }
                }
            }
            else if (status == 1)
            {
                if (name == "SceneSwitchLvl3_02")
                {
                    if (camera.transform.position.x < camXStart + camMove)
                    {
                        camera.transform.Translate(camSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        LevelManager.canPause = true;
                        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                        status = 0;
                        cameraMove = false;
                    }
                }
                else
                {
                    if (camera.transform.position.x > camXStart - camMove)
                    {
                        camera.transform.Translate(-camSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        LevelManager.canPause = true;
                        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                        status = 0;
                        cameraMove = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.canPause = false;
            other.GetComponent<Animator>().SetBool("IsWalking", false);
            other.GetComponent<PlayerController>().enabled = false;
            Vector2 stop = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().velocity = stop;
            camXStart = camera.transform.position.x;
            cameraMove = true;
            if (status == 0)
            {
                if (name == "SceneSwitchLvl3")
                {
                    Destroy(GameObject.Find("SceneSwitchLvl3_02"));
                }
                if (name == "SceneSwitchLvl3_02" && !lvl3Triggered)
                {
                    camMove -= 4;
                    triggerMove -= 2;
                    Destroy(GameObject.Find("SceneSwitchLvl3"));
                    Vector3 newTrigPos = new Vector3(transform.position.x + triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
                else if (name == "SceneSwitchLvl3_02" && lvl3Triggered)
                {
                    Vector3 newTrigPos = new Vector3(transform.position.x + triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
                else
                {
                    Vector3 newTrigPos = new Vector3(transform.position.x - triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
            }
            else if (status == 1)
            {
                if (name == "SceneSwitchLvl3" && !lvl3Triggered)
                {
                    camMove += 10;
                    triggerMove -= 8;
                    lvl3Triggered = true;
                }
                if (name == "SceneSwitchLvl3_02" && !lvl3Triggered)
                {
                    camMove += 14;
                    triggerMove -= 2;
                    lvl3Triggered = true;
                    Vector3 newTrigPos = new Vector3(transform.position.x - triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
                else if (name == "SceneSwitchLvl3_02" && lvl3Triggered)
                {
                    Vector3 newTrigPos = new Vector3(transform.position.x - triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
                else
                {
                    Vector3 newTrigPos = new Vector3(transform.position.x + triggerMove, transform.position.y, transform.position.z);
                    transform.position = newTrigPos;
                }
            }
        }
    }

}
