using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    #region variables
    public string startPoint_Name;
    #endregion

    #region GameObjects
    private GameWorldController gameWorld;
    private PlayerController player;
    #endregion GameObjects

    #region LookDirection
    public Vector2 startDirection;
    #endregion LookDirection

    // Use this for initialization
    void Start () {
        gameWorld = FindObjectOfType<GameWorldController>();
        player = FindObjectOfType<PlayerController>();
        if(player.startPoint_Name == startPoint_Name)
        {
            gameWorld.transform.position = gameWorld.transform.position - transform.position;
            #region Player Animation
            gameWorld.lastMove_P = startDirection;
            player.lastMove = startDirection;
            #endregion Player Animation
            player.Player_LockMovement = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
