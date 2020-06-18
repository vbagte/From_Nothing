using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSoundEmitter : MonoBehaviour
{
    private FMOD.Studio.EventInstance crystalEmitter;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Debug.Log("crystal sound start");
        crystalEmitter = FMODUnity.RuntimeManager.CreateInstance("event:/Environment/Emitters/crystal");
        crystalEmitter.start();
        crystalEmitter.release();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(crystalEmitter, transform, rb2D);
    }

    void OnDestroy()
    {
        //Debug.Log("crystal sound active");
        crystalEmitter.setParameterByName("active", 1);
    }
}
