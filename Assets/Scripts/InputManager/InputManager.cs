using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

    #region Singleton
    private static InputManager _Instance = null;

    protected InputManager()
    {

    }

    public static InputManager Instance()
    {
        if (_Instance == null) _Instance = new InputManager();
        return _Instance;
    }
    #endregion Singleton

    #region deadZone variable

    private static float axis_deadZone = 0.19f; //Default: 0.19f

    #endregion deadZone variable

    #region Axis

    #region Joysticks

    #region Left Joystick

    #region LeftStick Horizontal
    private const string C_LeftStick_Horizontal_Name = "C_LeftStick_Horizontal";
    private const string K_LeftStick_Horizontal_Name = "K_LeftStick_Horizontal";
    private static float LeftStick_Horizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_LeftStick_Horizontal_Name);
        result += Input.GetAxis(K_LeftStick_Horizontal_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool LeftStick_Horizontal_IsDeadZone()
    {
        float x = LeftStick_Horizontal();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion LeftStick Horizontal

    #region LeftStick Vertical
    private const string C_LeftStick_Vertical_Name = "C_LeftStick_Vertical";
    private const string K_LeftStick_Vertical_Name = "K_LeftStick_Vertical";
    private static float LeftStick_Vertical()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_LeftStick_Vertical_Name);
        result += Input.GetAxis(K_LeftStick_Vertical_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool LeftStick_Vertical_IsDeadZone()
    {
        float x = LeftStick_Vertical();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion LeftStick Vertical

    #region LeftStick JoyStick
    public static Vector3 Joystick_LeftStick()
    {
        return new Vector3(LeftStick_Horizontal(), LeftStick_Vertical(), 0);
    }
    public static bool LeftStick_IsDeadZone()
    {
        return (LeftStick_Horizontal_IsDeadZone() && LeftStick_Vertical_IsDeadZone()) ? true : false;
    }
    #endregion LeftStick JoyStick

    #endregion Left Joystick

    #region Right Joystick

    #region RightStick Horizontal
    private const string C_RightStick_Horizontal_Name = "C_RightStick_Horizontal";
    private const string K_RightStick_Horizontal_Name = "K_RightStick_Horizontal";
    private static float RightStick_Horizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_RightStick_Horizontal_Name);
        result += Input.GetAxis(K_RightStick_Horizontal_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }

    public static bool RightStick_Horizontal_IsDeadZone()
    {
        float x = RightStick_Horizontal();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion RightStick Horizontal

    #region RightStick Vertical
    private const string C_RightStick_Vertical_Name = "C_RightStick_Vertical";
    private const string K_RightStick_Vertical_Name = "K_RightStick_Vertical";
    private static float RightStick_Vertical()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_RightStick_Vertical_Name);
        result += Input.GetAxis(K_RightStick_Vertical_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool RightStick_Vertical_IsDeadZone()
    {
        float x = RightStick_Vertical();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion RightStick Vertical

    #region RightStick JoyStick

    public static Vector3 Joystick_RightStick()
    {
        return new Vector3(RightStick_Horizontal(), RightStick_Vertical(), 0);
    }

    public static bool RightStick_IsDeadZone()
    {
        return (RightStick_Horizontal_IsDeadZone() && RightStick_Vertical_IsDeadZone()) ? true : false;
    }

    #endregion RightStick JoyStick

    #endregion Right Joystick

    #endregion Joysticks

    #region Triggers

    #region Left Trigger

    #region Left

    private const string C_LeftTrigger_Name = "C_LeftTrigger";
    private const string K_LeftTrigger_Name = "K_LeftTrigger";
    private static float LeftTrigger()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_LeftTrigger_Name);
        result += Input.GetAxis(K_LeftTrigger_Name);
        result = Mathf.Clamp(result, 0.0f, 1.0f); //-1.0f, 1.0f
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool LeftTrigger_IsDeadZone()
    {
        float x = LeftTrigger();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }

    #endregion Left

    #region Trigger

    public static Vector3 Trigger_Left()
    {
        return new Vector3(0, LeftTrigger(), 0);
    }
    public static bool Trigger_Left_IsDeadZone()
    {
        return (LeftTrigger_IsDeadZone()) ? true : false;
    }

    #endregion Trigger

    #endregion Left Trigger

    #region Right Trigger

    #region Right

    private const string C_RightTrigger_Name = "C_RightTrigger";
    private const string K_RightTrigger_Name = "K_RightTrigger";
    private static float RightTrigger()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_RightTrigger_Name);
        result += Input.GetAxis(K_RightTrigger_Name);
        result = Mathf.Clamp(result, 0.0f, 1.0f); //-1.0f, 1.0f
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool RightTrigger_IsDeadZone()
    {
        float x = RightTrigger();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }

    #endregion Right

    #region Trigger

    public static Vector3 Trigger_Right()
    {
        return new Vector3(0, RightTrigger(), 0);
    }
    public static bool Trigger_Right_IsDeadZone()
    {
        return (RightTrigger_IsDeadZone()) ? true : false;
    }

    #endregion Trigger

    #endregion Right Trigger

    #endregion Triggers

    #region DPad 

    #region DPad Horizontal
    private const string C_DPad_Horizontal_Name = "C_DPad_Horizontal";
    private const string K_DPad_Horizontal_Name = "K_DPad_Horizontal";
    private static float DPad_Horizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_DPad_Horizontal_Name);
        result += Input.GetAxis(K_DPad_Horizontal_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool DPad_Horizontal_IsDeadZone()
    {
        float x = DPad_Horizontal();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion DPad Horizontal

    #region DPad Vertical
    private const string C_DPad_Vertical_Name = "C_DPad_Vertical";
    private const string K_DPad_Vertical_Name = "K_DPad_Vertical";
    private static float DPad_Vertical()
    {
        float result = 0.0f;
        result += Input.GetAxis(C_DPad_Vertical_Name);
        result += Input.GetAxis(K_DPad_Vertical_Name);
        result = Mathf.Clamp(result, -1.0f, 1.0f);
        return (Mathf.Abs(result) > axis_deadZone) ? result : 0;
    }
    public static bool DPad_Vertical_IsDeadZone()
    {
        float x = DPad_Vertical();
        return (Mathf.Abs(x) > axis_deadZone) ? false : true;
    }
    #endregion DPad Vertical

    #region DPad 
    public static Vector3 DPad()
    {
        return new Vector3(DPad_Horizontal(), DPad_Vertical(), 0);
    }
    public static bool DPad_IsDeadZone()
    {
        return (DPad_Horizontal_IsDeadZone() && DPad_Vertical_IsDeadZone()) ? true : false;
    }
    #endregion DPad

    #endregion DPad

    #endregion Axis

    #region Buttons

    #region Interaction

    #region Cross
    private const string Cross_Button_Name = "Cross_Button";
    public static bool Button_Cross_Down()
    {
        return Input.GetButtonDown(Cross_Button_Name);
    }
    public static bool Button_Cross_Up()
    {
        return Input.GetButtonUp(Cross_Button_Name);
    }
    #endregion Cross

    #region Circle
    private const string Circle_Button_Name = "Circle_Button";
    public static bool Button_Circle_Down()
    {
        return Input.GetButtonDown(Circle_Button_Name);
    }
    public static bool Button_Circle_Up()
    {
        return Input.GetButtonUp(Circle_Button_Name);
    }
    #endregion Circle

    #region Square
    private const string Square_Button_Name = "Square_Button";
    public static bool Button_Square_Down()
    {
        return Input.GetButtonDown(Square_Button_Name);
    }
    public static bool Button_Square_Up()
    {
        return Input.GetButtonUp(Square_Button_Name);
    }
    #endregion Square

    #region Triangle
    private const string Triangle_Button_Name = "Triangle_Button";
    public static bool Button_Triangle_Down()
    {
        return Input.GetButtonDown(Triangle_Button_Name);
    }
    public static bool Button_Triangle_Up()
    {
        return Input.GetButtonUp(Triangle_Button_Name);
    }
    #endregion Triangle

    #endregion Interaction

    #region Bumpers

    #region LeftBumper
    private const string LeftBumper_Button_Name = "LeftBumper_Button";
    public static bool Button_LeftBumper_Down()
    {
        return Input.GetButtonDown(LeftBumper_Button_Name);
    }
    public static bool Button_LeftBumper_Up()
    {
        return Input.GetButtonUp(LeftBumper_Button_Name);
    }
    #endregion LeftBumper

    #region RightBumper
    private const string RightBumper_Button_Name = "RightBumper_Button";
    public static bool Button_RightBumper_Down()
    {
        return Input.GetButtonDown(RightBumper_Button_Name);
    }
    public static bool Button_RightBumper_Up()
    {
        return Input.GetButtonUp(RightBumper_Button_Name);
    }
    #endregion RightBumper

    #endregion Bumpers

    #region Share/Option/PS/Pad

    #region Share
    private const string Share_Button_Name = "Share_Button";
    public static bool Button_Share_Down()
    {
        return Input.GetButtonDown(Share_Button_Name);
    }
    public static bool Button_Share_Up()
    {
        return Input.GetButtonUp(Share_Button_Name);
    }
    #endregion Share

    #region Options
    private const string Options_Button_Name = "Options_Button";
    public static bool Button_Options_Down()
    {
        return Input.GetButtonDown(Options_Button_Name);
    }
    public static bool Button_Options_Up()
    {
        return Input.GetButtonUp(Options_Button_Name);
    }
    #endregion Options

    #region PlayStation
    private const string PlayStation_Button_Name = "PlayStation_Button";
    public static bool Button_PlayStation_Down()
    {
        return Input.GetButtonDown(PlayStation_Button_Name);
    }
    public static bool Button_PlayStation_Up()
    {
        return Input.GetButtonUp(PlayStation_Button_Name);
    }
    #endregion PlayStation

    #region PadPress
    private const string PadPress_Button_Name = "PadPress_Button";
    public static bool Button_PadPress_Down()
    {
        return Input.GetButtonDown(PadPress_Button_Name);
    }
    public static bool Button_PadPress_Up()
    {
        return Input.GetButtonUp(PadPress_Button_Name);
    }
    #endregion PadPress

    #endregion Share/Option/PS/Pad

    #region StickClick

    #region LeftStickClick
    private const string LeftStickClick_Button_Name = "LeftStickClick_Button";
    public static bool Button_LeftStickClick_Down()
    {
        return Input.GetButtonDown(LeftStickClick_Button_Name);
    }
    public static bool Button_LeftStickClick_Up()
    {
        return Input.GetButtonUp(LeftStickClick_Button_Name);
    }
    #endregion LeftStickClick

    #region RightStickClick
    private const string RightStickClick_Button_Name = "RightStickClick_Button";
    public static bool Button_RightStickClick_Down()
    {
        return Input.GetButtonDown(RightStickClick_Button_Name);
    }
    public static bool Button_RightStickClick_Up()
    {
        return Input.GetButtonUp(RightStickClick_Button_Name);
    }
    #endregion RightStickClick

    #endregion StickClick

    #region Triggers

    #region Left
    private const string LeftTrigger_Button_Name = "LeftTrigger_Button";
    public static bool Button_LeftTrigger_Down()
    {
        return Input.GetButtonDown(LeftTrigger_Button_Name);
    }
    public static bool Button_LeftTrigger_Up()
    {
        return Input.GetButtonUp(LeftTrigger_Button_Name);
    }
    #endregion Left

    #region Right
    private const string RightTrigger_Button_Name = "RightTrigger_Button";
    public static bool Button_RightTrigger_Down()
    {
        return Input.GetButtonDown(RightTrigger_Button_Name);
    }
    public static bool Button_RightTrigger_Up()
    {
        return Input.GetButtonUp(RightTrigger_Button_Name);
    }
    #endregion Right

    #endregion Triggers

    #region DPad

    #region Left
    private static bool Button_DPad_Left_Pressed = false;
    public static bool Button_DPad_Left_Down()
    {
        float x = DPad_Horizontal();
        if (x < 0 && x < (axis_deadZone * -1.0f) && !Button_DPad_Left_Pressed)
        {
            Button_DPad_Left_Pressed = true;
            return true;
        }
        return false;
    }
    public static bool Button_DPad_Left_Up()
    {
        float x = DPad_Horizontal();
        if (x >= 0 && x >= (axis_deadZone * -1.0f) && Button_DPad_Left_Pressed)
        {
            Button_DPad_Left_Pressed = false;
            return true;
        }
        return false;
    }
    #endregion Left

    #region Up
    private static bool Button_DPad_Up_Pressed = false;
    public static bool Button_DPad_Up_Down()
    {
        float x = DPad_Vertical();
        if (x > 0 && x > axis_deadZone && !Button_DPad_Up_Pressed)
        {
            Button_DPad_Up_Pressed = true;
            return true;
        }
        return false;
    }
    public static bool Button_DPad_Up_Up()
    {
        float x = DPad_Vertical();
        if (x >= 0 && x <= axis_deadZone && Button_DPad_Up_Pressed)
        {
            Button_DPad_Up_Pressed = false;
            return true;
        }
        return false;
    }
    #endregion Up

    #region Right
    private static bool Button_DPad_Right_Pressed = false;
    public static bool Button_DPad_Right_Down()
    {
        float x = DPad_Horizontal();
        if (x > 0 && x > axis_deadZone && !Button_DPad_Right_Pressed)
        {
            Button_DPad_Right_Pressed = true;
            return true;
        }
        return false;
    }
    public static bool Button_DPad_Right_Up()
    {
        float x = DPad_Horizontal();
        if (x >= 0 && x <= axis_deadZone && Button_DPad_Right_Pressed)
        {
            Button_DPad_Right_Pressed = false;
            return true;
        }
        return false;
    }
    #endregion Right

    #region Down
    private static bool Button_DPad_Down_Pressed = false;
    public static bool Button_DPad_Down_Down()
    {
        float x = DPad_Vertical();
        if (x < 0 && x < (axis_deadZone * -1.0f) && !Button_DPad_Down_Pressed)
        {
            Button_DPad_Down_Pressed = true;
            return true;
        }
        return false;
    }
    public static bool Button_DPad_Down_Up()
    {
        float x = DPad_Vertical();
        if (x <= 0 && x >= (axis_deadZone * -1.0f) && Button_DPad_Down_Pressed)
        {
            Button_DPad_Down_Pressed = false;
            return true;
        }
        return false;
    }
    #endregion Down

    #endregion DPad 

    #endregion Buttons

}
