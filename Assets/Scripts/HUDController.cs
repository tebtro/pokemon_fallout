using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {

    #region SceneLoader
    private static bool hudControllerExists;
    #endregion SceneLoader

    // Use this for initialization
    void Start () {
        #region SceneLoader
        if (!hudControllerExists)
        {
            DontDestroyOnLoad(transform.gameObject);
            hudControllerExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion Scene Loader
    }

    // Update is called once per frame
    void Update () {
		
	}
}
