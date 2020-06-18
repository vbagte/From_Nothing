using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalconyHurt : MonoBehaviour
{

    public GameObject player;

    public bool hurtActive = false;
    public bool balconyActive = false;

    public void Start()
    {
        player = GameObject.Find("Player");
        //StartCoroutine(BalconyActive());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player") && balconyActive)
        {
            hurtActive = true;
            StopCoroutine("PlayerHurt");
            StartCoroutine("PlayerHurt");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player") && balconyActive)
        {
            hurtActive = false;
            StopCoroutine("PlayerHurt");
        }
    }

    IEnumerator PlayerHurt()
    {
        while (hurtActive)
        {
            player.GetComponent<PlayerController>().HealthLose();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator BalconyActive()
    {
        yield return new WaitForSeconds(2);
        balconyActive = true;
    }

}
