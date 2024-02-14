using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Name of the parameter in the audio mixer for master volume
    public string masterVolumeParameter = "volume";

    // Name of the parameter in the audio mixer for sound effects volume
    public string sfxVolumeParameter = "sfxVolume";

    // Function to set the master volume
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(masterVolumeParameter, volume);
    }

    // Function to set the sound effects volume
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfxVolumeParameter, volume);
    }
}
