using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVol : MonoBehaviour {

    public AudioMixer masterMixer;

    public void SetAudioLvl(float audioLvl)
    {
        masterMixer.SetFloat("masterVol", audioLvl);
    }
	
}
