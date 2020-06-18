using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_02_movement : MonoBehaviour
{
    public static bool spawnActive = false;
    public static int slimeDead;
    public static float speedOriginal;
    public static float healthOriginal;

    public GameObject player;
    public GameObject slime;
    public GameObject slimeSpawn;
    public GameObject slimeLight;
    public GameObject slimeStation;
    public GameObject crystal;
    public float distanceToMove;
    public float distanceFromPlayer;
    public float speed;
    public float jumpSpeed;
    public float jumpTime;
    public float pushSpeed;
    public float health;

    private float currPos;
    private float newPos;
    private float newPos2;
    private bool startPos = true;
    private bool slimePos = false;
    private bool playerNear = false;
    private bool jumpCall = false;
    private bool dead = false;

    private float step;
    private Vector2 target;

    private void Start()
    {
        if (spawnActive)
        {
            slimePos = true;
            speed = 0;
            StartCoroutine(SlimeStart());
        }
        else
        {
            currPos = transform.position.x;
            newPos = transform.position.x + distanceToMove;
            newPos2 = transform.position.x - distanceToMove;
        }
        player = GameObject.Find("Player");
        slimeSpawn = GameObject.Find("slimeSpawn");
        slimeLight = GameObject.Find("slimeLight");
        slimeStation = GameObject.Find("slimeStation");
    }

    private void Update()
    {

        if (slimePos)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < distanceFromPlayer && transform.localPosition.y < -5)
        {
            playerNear = true;
            if (!jumpCall)
            {
                StartCoroutine("SlimeJump");
                jumpCall = true;
            }
        }
        else
        {
            StopCoroutine("SlimeJump");
            playerNear = false;
            jumpCall = false;
        }

        if (!playerNear)
        {
            if (startPos && !slimePos)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                if (transform.position.x >= newPos)
                {
                    startPos = false;
                }
            }
            else if (!startPos && !slimePos)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                if (transform.position.x <= newPos2)
                {
                    startPos = true;
                }
            }
        }
        else
        {
            target = new Vector3(player.transform.position.x, transform.position.y, transform.localPosition.z);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        if (health <= 0 && !dead)
        {
            Death();
            dead = true;
        }

    }

    void Death()
    {
        print(slimeDead);
        print(SlimeStation.enemySpawns);
        healthOriginal = health;
        speedOriginal = speed;
        GameObject.Find("slimeStation").GetComponent<SlimeStation>().enabled = true;
        if (spawnActive)
        {
            slimeDead += 1;
            if (slimeDead == slimeStation.GetComponent<SlimeStation>().slimeCount && Level_01_Interact_Manager.statusCrystal4 < 2)
            {
                Vector3 crystalPos = new Vector3(transform.position.x, -3.5f, transform.position.z);
                GameObject key = Instantiate(crystal, crystalPos, crystal.transform.rotation);
                key.name = "crystal4";
            }
        }
        Destroy(gameObject);
        spawnActive = true;
    }

    IEnumerator SlimeJump()
    {
        jumpCall = true;
        while (playerNear)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            yield return new WaitForSeconds(jumpTime);
        }
    }

    IEnumerator SlimeStart()
    {
        yield return new WaitForSeconds(1);
        slimePos = false;
        speed = speedOriginal;
        yield return new WaitForSeconds(2);
        currPos = transform.position.x;
        newPos = transform.position.x + distanceToMove + 10;
        newPos2 = currPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerController>().JumpLose();
            other.transform.GetComponent<PlayerController>().ShotLose();
            if (transform.position.x < other.transform.position.x)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * pushSpeed);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * pushSpeed);
            }
        }
    }

}
