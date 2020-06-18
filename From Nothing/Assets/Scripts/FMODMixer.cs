using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODMixer : MonoBehaviour
{
    FMOD.Studio.EventInstance sfxTestEvent;
    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus sfxBus;
    private float musicVolume = 0.5f;
    private float sfxVolume = 0.5f;

    private void Start()
    {
        sfxTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Environment/Interactables/gempickup");
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
    }

    private void Update()
    {
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(sfxVolume);
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        sfxVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE playbackState;
        sfxTestEvent.getPlaybackState(out playbackState);
        if (playbackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            sfxTestEvent.start();
        }

    }

}
