using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    #region Axis
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    #endregion Axis
    #region Movement
    public const string MOVEX = "MoveX";
    public const string MOVEY = "MoveY";
    public const string LASTMOVEX = "LastMoveX";
    public const string LASTMOVEY = "LastMoveY";
    public const string PLAYERMOVING = "PlayerMoving";
    #endregion Movement
    #region Player
    public const string PLAYER_NAME = "Player";
    #endregion Player

    #region Scenes
    public const string TEST_ENVIRONMENT_NAME = "";
    public const int TEST_ENVIRONMENT_ID = 0;

    public const string TEST_ENVIRONMENT_INSIDE_NAME = "";
    public const int TEST_ENVIRONMENT_INSIDE_ID = 1;
    #endregion Scenes
    #region SceneLoader
    public const string SPAWNPOINT = "SpawnPoint";

    public static string INPUT_RUN { get; internal set; }
    #endregion SceneLoader

    #region AudioManager
    #region SE
    public const string SE_DOOR_ENTER = "se_door_enter";
    public const string SE_DOOR_EXIT = "se_door_exit";
    public const string SE_RUN = "se_run";
    #endregion SE
    #region BGM
    #region Pokémon
    public const string BGM_HOF_ROOM = "bgm_hof_room";
    public const string BGM_ROUTE = "bgm_route";
    #endregion Pokémon
    #region Fallout
    public const string BGM_01_FALLOUT4_MAIN_THEME = "bgm_01_fallout_4_main_theme";
    public const string BGM_02_THE_COMMONWEALTH = "bgm_02_the_commonwealth";
    public const string BGM_03_OF_GREEN_AND_GREY = "bgm_03_of_green_and_grey";
    #endregion Fallout
    #endregion BGM
    #endregion AudioManager
    #region DialogueManager
    public const string DIALOGUE_ISOPEN = "IsOpen";
    #endregion DialogueManager
}
