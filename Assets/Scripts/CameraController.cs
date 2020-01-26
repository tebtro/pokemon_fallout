using UnityEngine;

/*
 *  This script is not needed to follow the Players Movement, 
 *      because the player is at a static position, we are only moving the world.
 *  This script can be used to follow different GameObjects or to create CameraPath!
 */
public class CameraController : MonoBehaviour {

    #region SceneLoader
    private static bool cameraExists;
    #endregion SceneLoader

    // Use this for initialization
    void Start () {
        #region SceneLoader
        if (!cameraExists)
        {
            DontDestroyOnLoad(transform.gameObject);
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion Scene Loader
    }

}
