using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    #region Singleton
    private static AudioManager _Instance = null;

    protected AudioManager()
    {

    }

    private void Awake()
    {
        if (_Instance == null) _Instance = this;
    }

    public static AudioManager Instance()
    {
        return _Instance;
    }
    #endregion Singleton


    #region AudioManager variables

    #endregion AudioManager variables
    #region SceneLoader
    private static bool audioManagerExists;
    #endregion SceneLoader
    #region SE
    [Header("SE AudioSource's")]
    public List<AudioSource> se_audioSources;
    Dictionary<string, int> se_audioSourceNames = new Dictionary<string, int>()
    {
        {Constants.SE_DOOR_ENTER, 0},
        {Constants.SE_DOOR_EXIT, 1},
        {Constants.SE_RUN, 2}
    };
    #endregion SE
    #region BGM
    [Header("BGM AudioSource's")]
    public List<AudioSource> bgm_audioSources;
    Dictionary<string, int> bgm_audioSourceNames = new Dictionary<string, int>()
    {
        {Constants.BGM_01_FALLOUT4_MAIN_THEME, 0},
        {Constants.BGM_02_THE_COMMONWEALTH, 1},
        {Constants.BGM_03_OF_GREEN_AND_GREY, 2}
    };

    public string currentBGM_name;
    public bool bgm_canPlay;
    #endregion BGM
    #region AudioSource Volume Manager
    public AudioSourceController[] audioSourceControllers;
    public float volumeLevel_max = 1.0f;
    public float volumeLevel_current = 0.9f;
    #endregion AudioSource Volume Manager

    // Use this for initialization
    void Start () {
        #region SceneLoader
        if (!audioManagerExists)
        {
            DontDestroyOnLoad(transform.gameObject);
            audioManagerExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion Scene Loader
        #region AudioSource Volume Manager
        audioSourceControllers = FindObjectsOfType<AudioSourceController>();
        if(volumeLevel_current > volumeLevel_max)
        {
            volumeLevel_current = volumeLevel_max;
        }
        SetVolumeLevel(volumeLevel_current);
        #endregion AudioSource Volume Manager
    }

    #region AudioSource Volume Manager
    public void SetVolumeLevel(float newVolumeLevel)
    {
        if (newVolumeLevel <= volumeLevel_max) volumeLevel_current = newVolumeLevel; else return;
        for (int i = 0; i < audioSourceControllers.Length; i++)
        {
            audioSourceControllers[i].SetVolumeLevel(volumeLevel_current);
        }
    }
    #endregion AudioSource Volume Manager

    // Update is called once per frame
    void Update () {
        #region BGM
        if (currentBGM_name != null && currentBGM_name != "")
        {
            if (bgm_canPlay)
            {
                if(!bgm_audioSources[bgm_audioSourceNames[currentBGM_name]].isPlaying)
                {
                    bgm_audioSources[bgm_audioSourceNames[currentBGM_name]].Play();
                }
            }
            else
            {
                bgm_audioSources[bgm_audioSourceNames[currentBGM_name]].Stop();
            }
        }
        #endregion BGM
    }

    #region Switch BGM Audio Source
    public void Switch_BGM_Audio(string newBGM_name)
    {
        if(newBGM_name != null && newBGM_name != "")
        {
            bgm_audioSources[bgm_audioSourceNames[currentBGM_name]].Stop();
            currentBGM_name = newBGM_name;
            bgm_audioSources[bgm_audioSourceNames[currentBGM_name]].Play();
        }
    }
    #endregion Switch BGM Audio Source

    #region Play SE Audio From String
    public void PlayStop_SE_Audio(string audioSource_Name, bool play)
    {
        if (audioSource_Name == null || audioSource_Name == "") return;
        switch(audioSource_Name)
        {
            case Constants.SE_DOOR_ENTER: if (play && !se_audioSources[se_audioSourceNames[Constants.SE_DOOR_ENTER]].isPlaying) se_audioSources[se_audioSourceNames[Constants.SE_DOOR_ENTER]].Play();
                                                else se_audioSources[se_audioSourceNames[Constants.SE_DOOR_ENTER]].Stop();
                break;
            case Constants.SE_DOOR_EXIT: if (play && !se_audioSources[se_audioSourceNames[Constants.SE_DOOR_EXIT]].isPlaying) se_audioSources[se_audioSourceNames[Constants.SE_DOOR_EXIT]].Play();
                                                else se_audioSources[se_audioSourceNames[Constants.SE_DOOR_EXIT]].Stop();
                break;
            case Constants.SE_RUN: if (play && !se_audioSources[se_audioSourceNames[Constants.SE_RUN]].isPlaying) se_audioSources[se_audioSourceNames[Constants.SE_RUN]].Play();
                                            else se_audioSources[se_audioSourceNames[Constants.SE_RUN]].Stop();
                break;

            default: return;
        }
    }
    #endregion Play SE Audio From String
}
