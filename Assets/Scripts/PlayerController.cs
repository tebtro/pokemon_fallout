using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Player Movement variables
    public float moveSpeed_Multiplier = 1.0f;
    private float moveSpeed_Base = 3.0f;
    public float moveSpeed_Base_P
    {
        get { return moveSpeed_Base; }
        set { moveSpeed_Base = value; }
    }
    public float moveSpeed_Multiplier_isRunning = 1.75f;
    public bool player_isRunning = false;
    private bool playerMoving;
    public bool playerMoving_P
    {
        get { return playerMoving; }
        set { playerMoving = value; }
    }
    public Vector2 lastMove;
    private bool player_LockMovement = false;
    public bool Player_LockMovement
    {
        get { return player_LockMovement; }
        set { player_LockMovement = value; }
    }

    #endregion Player Movement variables

    #region SceneLoader
    private static bool playerExists;
    public string startPoint_Name;
    #endregion SceneLoader
    
    void Start () {
        #region SceneLoader
        if (!playerExists)
        {
            DontDestroyOnLoad(transform.gameObject);
            playerExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion Scene Loader
    }

    #region getMoveSpeed()
    /*
     * getMoveSpeed()
     * Created for changing the move speed when the player is running or similar
     */
    public float getMoveSpeed()
    {
        float moveSpeed = 0.0f;
        moveSpeed = moveSpeed_Base * moveSpeed_Multiplier;
        if (player_isRunning)
        {
            moveSpeed *= moveSpeed_Multiplier_isRunning;
        }
        return moveSpeed;
    }
    #endregion getMoveSpeed()
}
