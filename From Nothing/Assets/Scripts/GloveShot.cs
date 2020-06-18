using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveShot : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_02_movement>().health -= 1;
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Chimera>().HealthLost();
            Destroy(gameObject);
        }
    }

}
