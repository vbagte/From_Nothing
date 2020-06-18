using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{

    public GameObject player;
    public GameObject explosion;
    public float time;

    IEnumerator Start()
    {
        player = GameObject.Find("Player");
        yield return new WaitForSeconds(time);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            player.GetComponent<PlayerController>().HealthLose();
            Destroy(gameObject);
        }
    }

}
