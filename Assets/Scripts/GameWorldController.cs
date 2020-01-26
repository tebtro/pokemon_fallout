using System;
using UnityEngine;

public class GameWorldController : MonoBehaviour {

    #region extension variables / constants
    //All in Classes/Constants
    #endregion extension variables / constants
    #region Player Movement variables
    private float moveSpeed = 1.0f; //Calculated in getMoveSpeed and used for Movement
    private bool player_isMoving;
    private Vector2 lastMove;
    public Vector2 lastMove_P
    {
        get { return lastMove; }
        set { lastMove = value; }
    }
    private Vector3 direction;
    #endregion Player Movement variables
    #region Rigidbody Movement variables
    private Rigidbody2D GameWorldsRigidbody;
    #endregion
    #region Player Animation
    private Animator anim; //Animator for Player Animation
    private PlayerController playerController;
    private GameObject player;
    #endregion Player Animation
    #region AudioManager
    private AudioManager audioManager;
    #endregion AudioManager
    
    void Start () {
        Initialize();
    }

    private void Initialize ()
    {
        #region AudioManager
        audioManager = FindObjectOfType<AudioManager>();
        #endregion AudioManager
        #region Rigidbody Movement
        GameWorldsRigidbody = GetComponent<Rigidbody2D>();
        #endregion
        #region Player Animation
        PlayerController playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        if (player != null) anim = player.GetComponent<Animator>();
        #endregion Player Animation
        #region Player Movement variables
        player_isMoving = playerController.playerMoving_P;
        lastMove = playerController.lastMove;
        #endregion Player Movement variables
    }
    
    void Update () {
        Movement();
    }

    #region Movement
    private void Movement()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController.Player_LockMovement == true) return;
        audioManager = FindObjectOfType<AudioManager>();
        
        Move_Run();
        
        player_isMoving = false;
        direction = InputManager.Joystick_LeftStick();

        Move();
        Move_Animation();
    }

    private void Move_Run()
    {
        if (InputManager.Button_Circle_Down() && !InputManager.LeftStick_IsDeadZone())
        {
            playerController.player_isRunning = true;
            audioManager.PlayStop_SE_Audio(Constants.SE_RUN, true);
        }
        if (InputManager.Button_Circle_Up())
        {
            playerController.player_isRunning = false;
            audioManager.PlayStop_SE_Audio(Constants.SE_RUN, false);
        }
        if (InputManager.LeftStick_IsDeadZone())
        {
            audioManager.PlayStop_SE_Audio(Constants.SE_RUN, false);
            playerController.player_isRunning = false;
        }
    }

    private void Move()
    {
        direction = direction.normalized * playerController.getMoveSpeed() * -1.0f * moveSpeed;

        Move_Horizontal();
        Move_Vertical();
        Move_Diagonal();
        
        Move_Stop();

        direction *= -1.0f;
    }

    private void Move_Horizontal()
    {
        if (!InputManager.LeftStick_Horizontal_IsDeadZone())
        {
            GameWorldsRigidbody.velocity = new Vector2(direction.x, GameWorldsRigidbody.velocity.y);
            player_isMoving = true;
            lastMove = new Vector2(direction.x * -1.0f, 0.0f);
        }
    }

    private void Move_Vertical()
    {
        if (!InputManager.LeftStick_Vertical_IsDeadZone())
        {
            GameWorldsRigidbody.velocity = new Vector2(GameWorldsRigidbody.velocity.x, direction.y);
            player_isMoving = true;
            lastMove = new Vector2(0.0f, direction.y * -1.0f);
        }
    }

    private void Move_Diagonal()
    {
        if (!InputManager.LeftStick_Horizontal_IsDeadZone() && !InputManager.LeftStick_Vertical_IsDeadZone())
        {
            GameWorldsRigidbody.velocity = new Vector2(direction.x, direction.y);
            player_isMoving = true;
            lastMove = new Vector2(direction.x * -1.0f, direction.y * -1.0f);
        }
    }

    private void Move_Stop()
    {
        if (InputManager.LeftStick_Horizontal_IsDeadZone())
        {
            GameWorldsRigidbody.velocity = new Vector2(0.0f, GameWorldsRigidbody.velocity.y);
        }
        if (InputManager.LeftStick_Vertical_IsDeadZone())
        {
            GameWorldsRigidbody.velocity = new Vector2(GameWorldsRigidbody.velocity.x, 0.0f);
        }
    }

    private void Move_Animation()
    {
        if (anim != null)
        {
            anim.SetFloat(Constants.MOVEX, direction.x);
            anim.SetFloat(Constants.MOVEY, direction.y);
            anim.SetBool(Constants.PLAYERMOVING, player_isMoving);
            anim.SetFloat(Constants.LASTMOVEX, lastMove.x);
            anim.SetFloat(Constants.LASTMOVEY, lastMove.y);
        }
    }
    #endregion Movement
}
