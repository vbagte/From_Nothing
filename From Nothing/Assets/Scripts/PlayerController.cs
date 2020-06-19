using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static bool canJump = false;
    public static bool doubleJumpActive = false;
    public static bool footprintActive = true;
    public static bool canShoot = false;

    public float moveSpeed = 3f;
    public float jumpSpeed = 1f;
    public GameObject footprint;
    public GameObject footprintSpot;
    public GameObject playerBoots;
    public GameObject playerGlove;
    public GameObject gloveShot;
    public GameObject shotSpawn;

    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask layerMask2;
    Vector3 original;
    Rigidbody2D rigidBody;
    Animator playerAnimator;
    Collider2D boxCollider2D;
    public bool canFootprint;
    public bool canJumpDouble;
    public bool isJumping;
    public GameObject[] batteryJump;
    public int batteryJumpMaxCharge;
    public int batteryJumpCurrentCharge;
    public GameObject[] batteryShoot;
    public int batteryShootMaxCharge;
    public int batteryShootCurrentCharge;
    public GameObject[] health;
    public int healthMax;
    public int healthCurrent;

    // Start is called before the first frame update
    void Start()
    {
        canFootprint = true;
        canJumpDouble = true;
        playerAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<Collider2D>();
        original = transform.localScale;
        batteryJump = GameObject.FindGameObjectsWithTag("BatteryJump");
        batteryJumpMaxCharge = batteryJump.Length;
        batteryJumpCurrentCharge = batteryJumpMaxCharge;
        batteryShoot = GameObject.FindGameObjectsWithTag("BatteryShoot");
        batteryShootMaxCharge = batteryShoot.Length;
        batteryShootCurrentCharge = batteryShootMaxCharge;
        health = GameObject.FindGameObjectsWithTag("Health");
        healthMax = health.Length;
        healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = original;
            shotSpawn.transform.localRotation = Quaternion.Euler(0, 90, 0);
            rigidBody.velocity = new Vector2(moveSpeed * 1, rigidBody.velocity.y);
            playerAnimator.SetBool("IsWalking", true);
            if (IsGrounded() && canFootprint)
            {
                StartCoroutine("FootPrint");
                canFootprint = false;

                // plays sound if player hits wall
                //if (!IsMoveRightPossible())
                //{
                //    RuntimeManager.PlayOneShot("event:/Player/wallcollide");
                //}
            }

            
        }
        //move left
        else if(Input.GetKey(KeyCode.A)){
            transform.localScale = new Vector3(original.x, original.y, -original.z);
            shotSpawn.transform.localRotation = Quaternion.Euler(0, -90, 0);
            rigidBody.velocity = new Vector2(moveSpeed * -1, rigidBody.velocity.y);
            playerAnimator.SetBool("IsWalking", true);
            if (IsGrounded() && canFootprint)
            {
                StartCoroutine("FootPrint");
                canFootprint = false;

                // plays sound if player hits wall
                //if (!IsMoveLeftPossible())
                //{
                //    RuntimeManager.PlayOneShot("event:/Player/wallcollide");
                //}
            }

            
        }
        //not moving
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            playerAnimator.SetBool("IsWalking", false);
            if (IsGrounded())
            {
                StopCoroutine("FootPrint");
                canFootprint = true;
            }
        }
        //jump
        if(Input.GetButtonDown("Jump") && IsGrounded() && canJump && batteryJumpCurrentCharge > 0)
        {
            // play sound
            RuntimeManager.PlayOneShot("event:/Player/jump");

            GetComponent<Animator>().SetInteger("JumpStatus", 1);
            playerBoots.GetComponent<Animation>().Stop();
            playerBoots.GetComponent<Animation>().Play();
            StartCoroutine(IsJumping());
            FootPrintStep();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            for (int i = 4; i >= 0; i--)
            {
                if (batteryJump[i].activeInHierarchy)
                {
                    batteryJump[i].SetActive(false);
                    batteryJumpCurrentCharge--;
                    break;
                }
            }
        }
        else if (Input.GetButtonDown("Jump") && IsGrounded() && canJump && batteryJumpCurrentCharge == 0)
        {
            RuntimeManager.PlayOneShot("event:/Player/batterylose");
        }
        //double jump
        if (Input.GetButtonDown("Jump") && !IsGrounded() && doubleJumpActive && canJumpDouble && batteryJumpCurrentCharge > 0)
        {
            // play sound
            RuntimeManager.PlayOneShot("event:/Player/doublejump");

            canJumpDouble = false;
            GetComponent<Animator>().SetInteger("JumpStatus", 1);
            playerBoots.GetComponent<Animation>().Stop();
            playerBoots.GetComponent<Animation>().Play();
            StartCoroutine(IsJumping());
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            JumpLose();
        }
        //landed
        if (IsGrounded() && isJumping)
        {
            RuntimeManager.PlayOneShot("event:/Player/wallcollide");
            canJumpDouble = true;
            GetComponent<Animator>().SetInteger("JumpStatus", 3);
            FootPrintStep();
            isJumping = false;
        }
        //glove shot
        if (Input.GetButtonDown("Fire1") && canShoot && batteryShootCurrentCharge > 0)
        {
            RuntimeManager.PlayOneShotAttached("event:/Player/attack", shotSpawn);
            playerGlove.GetComponent<Animation>().Play();
            Instantiate(gloveShot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            StartCoroutine(GloveShoot());
            ShotLose();
        }
        //else if (Input.GetButtonDown("Fire1") && canShoot && batteryShootCurrentCharge == 0)
        //{
        //    RuntimeManager.PlayOneShot("event:/Player/batterylose");
        //}
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down
        , .1f, layerMask);
        return raycastHit2d.collider;
    }

    private bool IsMoveRightPossible()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right
        , .1f, layerMask2);
        return !raycastHit2d.collider;
    }

    private bool IsMoveLeftPossible()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.left
        , .1f, layerMask2);
        return !raycastHit2d.collider;
    }

    IEnumerator IsJumping()
    {
        yield return new WaitForSeconds(0.1f);
        isJumping = true;
        GetComponent<Animator>().SetInteger("JumpStatus", 2);
    }

    IEnumerator FootPrint()
    {
        //yield return new WaitForSeconds(0.1f);
        if (IsGrounded())
        {
            FootPrintStep();
        }
        yield return new WaitForSeconds(0.2f);
        canFootprint = true;
    }

    IEnumerator GloveShoot()
    {

        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    public void FootPrintStep()
    {
        RuntimeManager.PlayOneShot("event:/Player/footsteps");
        if (footprintActive)
        {
            Vector3 step = new Vector3(transform.position.x, transform.position.y - .24f, -3);
            Instantiate(footprint, footprintSpot.transform.position, footprintSpot.transform.rotation);
        }
    }

    public void EnableBoots()
    {
        playerBoots.SetActive(true);
    }

    public void EnableGlove()
    {
        playerGlove.SetActive(true);
    }

    public void JumpLose()
    {
        for (int i = 4; i >= 0; i--)
        {
            if (batteryJump[i].activeInHierarchy)
            {
                batteryJump[i].SetActive(false);
                batteryJumpCurrentCharge--;
                break;
            }
        }
    }

    public void ShotLose()
    {
        for (int i = 9; i >= 0; i--)
        {
            if (batteryShoot[i].activeInHierarchy)
            {
                batteryShoot[i].SetActive(false);
                batteryShootCurrentCharge--;
                break;
            }
        }
    }

    public void HealthLose()
    {
        for (int i = healthMax - 1; i >= 0; i--)
        {
            if (health[i].activeInHierarchy)
            {
                RuntimeManager.PlayOneShot("event:/Player/healthlose");
                health[i].SetActive(false);
                healthCurrent--;
                break;
            }
        }
        if (healthCurrent <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        RuntimeManager.PlayOneShot("event:/Player/death");
        StopAllCoroutines();
        GameObject.Find("PlayerDeath").GetComponent<PlayerDeath>().StartCoroutine("Death");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChargeStation"))
        {
            RuntimeManager.PlayOneShot("event:/Environment/Interactables/batterycharge");
            for (int i = 0; i < batteryJump.Length; i++)
            {
                batteryJump[i].SetActive(true);
            }
            batteryJumpCurrentCharge = batteryJumpMaxCharge;
            for (int i = 0; i < batteryShoot.Length; i++)
            {
                batteryShoot[i].SetActive(true);
            }
            batteryShootCurrentCharge = batteryShootMaxCharge;
            //for (int i = 0; i < health.Length; i++)
            //{
            //    health[i].SetActive(true);
            //}
            //healthCurrent = healthMax;
        }
    }

}
