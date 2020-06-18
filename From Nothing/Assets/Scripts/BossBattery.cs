using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattery : MonoBehaviour
{

    public Transform batterySpot;

    private void Update()
    {
        Vector3 spotPos = new Vector3(batterySpot.position.x, batterySpot.position.y, transform.position.z);
        transform.position = spotPos;
    }

}
