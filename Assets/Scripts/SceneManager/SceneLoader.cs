using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    #region GameObjects
    public GameObject loadingScreen;
    public Slider progressBar_slider;
    public Text progressBar_text;
    #endregion GameObjects

    #region public variables
    public string sceneToLoad_Name;
    public string exitPoint_Name;
    [Header("Audio Source")]
    public string audioSource_name;
    #endregion public variables

    #region Controllers
    private PlayerController player;
    private AudioManager audioManager;
    #endregion

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        audioManager = FindObjectOfType<AudioManager>();
	}

    private void OnTriggerEnter2D(Collider2D collisionEntered)
    {
        if (collisionEntered.gameObject.name == Constants.PLAYER_NAME)
        {
            player.Player_LockMovement = true;
            if (sceneToLoad_Name == null) return;
            if(audioManager != null) audioManager.PlayStop_SE_Audio(audioSource_name, true);

            StartCoroutine(LoadAsynchronously());

            loadingScreen.SetActive(false);

            player.startPoint_Name = exitPoint_Name;
            player.player_isRunning = false;

            audioManager.PlayStop_SE_Audio(Constants.SE_RUN, false);
        }
    }

    private IEnumerator LoadAsynchronously ()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad_Name, LoadSceneMode.Single);

        DontDestroyOnLoad(loadingScreen);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar_slider.value = progress;
            progressBar_text.text = progress * 100f + "%";

            yield return null;
        }
        
    }

}
