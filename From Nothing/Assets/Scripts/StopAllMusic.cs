using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllMusic : MonoBehaviour
{
    private FMOD.Studio.Bus musicBus;
    // Start is called before the first frame update
    void Start()
    {
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");

    }

    private void OnEnable()
    {
        musicBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Debug.Log("MUSIC SHOULD BE STOPPING???");

    }

   
}
