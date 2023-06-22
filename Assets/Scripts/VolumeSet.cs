using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSet : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderVal){
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderVal)*20);
    }
}
