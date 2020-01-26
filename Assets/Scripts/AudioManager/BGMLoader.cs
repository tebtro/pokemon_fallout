using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLoader : MonoBehaviour {

    #region Controllers
    private AudioManager audioManager;
    #endregion Controllers

    #region variables
    public string newBGM_name;
    public bool loadOnStart; // load new BGM on new Scene
    #endregion variables

    // Use this for initialization
    void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        #region load new BGM on Start
        if(loadOnStart && newBGM_name != null && newBGM_name != "")
        {
            audioManager.Switch_BGM_Audio(newBGM_name);
            gameObject.SetActive(false);
        }
        #endregion load new BGM on Start
    }

    // Update is called once per frame
    void Update () {
		
	}

    #region load new BGM on triggerEnter2D
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == Constants.PLAYER_NAME)
        {
            if (newBGM_name != null && newBGM_name != "")
            {
                audioManager.Switch_BGM_Audio(newBGM_name);
                gameObject.SetActive(false);
            }
        }
    }
    #endregion load new BGM on triggerEnter2D
}
