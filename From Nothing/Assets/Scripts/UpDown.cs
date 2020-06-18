using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public bool startDown;
    public float speed, max, min;

    private int status;

    private void Start()
    {
        if (startDown)
        {
            status = 0;
        }
        else
        {
            status = 1;
        }
    }

    private void Update()
    {
        if (status == 0)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            if (transform.localPosition.y <= min)
            {
                status = 1;
            }
        }
        else if (status == 1)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            if (transform.localPosition.y >= max)
            {
                status = 0;
            }
        }
    }

}
