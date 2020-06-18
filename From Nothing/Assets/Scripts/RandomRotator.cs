using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    private float tumbleX, tumbleY, tumbleZ;

    private void Start()
    {
        tumbleX = Random.Range(50, 150);
        tumbleY = Random.Range(50, 150);
        tumbleZ = Random.Range(50, 150);
    }

    private void Update()
    {
        transform.Rotate(tumbleX * Time.deltaTime, tumbleY * Time.deltaTime, tumbleZ * Time.deltaTime);
    }

}
