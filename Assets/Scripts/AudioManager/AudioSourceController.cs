using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour {

    #region variables
    private AudioSource audioSource;
    #endregion variables

    #region Audio Volume Level
    float audioLevel_current;
    public float audioLevel_base;
    #endregion Audio Volume Level

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVolumeLevel(float volumeLevel_multiplier)
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioLevel_current = audioLevel_base * volumeLevel_multiplier;
        audioSource.volume = audioLevel_current;
    }
}
