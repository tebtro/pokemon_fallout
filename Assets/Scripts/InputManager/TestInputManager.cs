using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputManager : MonoBehaviour {

    // Update is called once per frame
    private void Update()
    {
        #region Buttons

        #region Interaction
        // Cross
        if (InputManager.Button_Cross_Down()) Debug.LogFormat("Button_Cross --> True \n");
        if (InputManager.Button_Cross_Up()) Debug.LogFormat("Button_Cross --> False \n");
        // Circle
        if (InputManager.Button_Circle_Down()) Debug.LogFormat("Button_Circle --> True \n");
        if (InputManager.Button_Circle_Up()) Debug.LogFormat("Button_Circle --> False \n");
        // Square
        if (InputManager.Button_Square_Down()) Debug.LogFormat("Button_Square --> True \n");
        if (InputManager.Button_Square_Up()) Debug.LogFormat("Button_Square --> False \n");
        // Triangle
        if (InputManager.Button_Triangle_Down()) Debug.LogFormat("Button_Triangle --> True \n");
        if (InputManager.Button_Triangle_Up()) Debug.LogFormat("Button_Triangle --> False \n");

        #endregion Interaction

        #region Bumpers
        // Left
        if (InputManager.Button_LeftBumper_Down()) Debug.LogFormat("Button_LeftBumper --> True \n");
        if (InputManager.Button_LeftBumper_Up()) Debug.LogFormat("Button_LeftBumper --> False \n");
        // Right
        if (InputManager.Button_RightBumper_Down()) Debug.LogFormat("Button_RightBumper --> True \n");
        if (InputManager.Button_RightBumper_Up()) Debug.LogFormat("Button_RightBumper --> False \n");

        #endregion Bumpers

        #region Share/Options/PS/PadPress
        // Share
        if (InputManager.Button_Share_Down()) Debug.LogFormat("Button_Share --> True \n");
        if (InputManager.Button_Share_Up()) Debug.LogFormat("Button_Share --> False \n");
        // Options
        if (InputManager.Button_Options_Down()) Debug.LogFormat("Button_Options --> True \n");
        if (InputManager.Button_Options_Up()) Debug.LogFormat("Button_Options --> False \n");
        // PlayStation
        if (InputManager.Button_PlayStation_Down()) Debug.LogFormat("Button_PlayStation --> True \n");
        if (InputManager.Button_PlayStation_Up()) Debug.LogFormat("Button_PlayStation --> False \n");
        // PadPress
        if (InputManager.Button_PadPress_Down()) Debug.LogFormat("Button_PadPress --> True \n");
        if (InputManager.Button_PadPress_Up()) Debug.LogFormat("Button_PadPress --> False \n");

        #endregion Share/Options/PS/PadPress

        #region StickClick
        // Left
        if (InputManager.Button_LeftStickClick_Down()) Debug.LogFormat("Button_LeftStickClick --> True \n");
        if (InputManager.Button_LeftStickClick_Up()) Debug.LogFormat("Button_LeftStickClick --> False \n");
        // Right
        if (InputManager.Button_RightStickClick_Down()) Debug.LogFormat("Button_RightStickClick --> True \n");
        if (InputManager.Button_RightStickClick_Up()) Debug.LogFormat("Button_RightStickClick --> False \n");

        #endregion StickClick

        #region TriggerButton
        // Left
        if (InputManager.Button_LeftTrigger_Down()) Debug.LogFormat("Button_LeftTrigger --> True \n");
        if (InputManager.Button_LeftTrigger_Up()) Debug.LogFormat("Button_LeftTrigger --> False \n");
        // Right
        if (InputManager.Button_RightTrigger_Down()) Debug.LogFormat("Button_RightTrigger --> True \n");
        if (InputManager.Button_RightTrigger_Up()) Debug.LogFormat("Button_RightTrigger --> False \n");

        #endregion TriggerButton

        #region DPad
        // Left
        if (InputManager.Button_DPad_Left_Down()) Debug.LogFormat("Button_DPad_Left --> True \n");
        if (InputManager.Button_DPad_Left_Up()) Debug.LogFormat("Button_DPad_Left --> False \n");
        // Up
        if (InputManager.Button_DPad_Up_Down()) Debug.LogFormat("Button_DPad_Up --> True \n");
        if (InputManager.Button_DPad_Up_Up()) Debug.LogFormat("Button_DPad_Up --> False \n");
        // Right
        if (InputManager.Button_DPad_Right_Down()) Debug.LogFormat("Button_DPad_Right --> True \n");
        if (InputManager.Button_DPad_Right_Up()) Debug.LogFormat("Button_DPad_Right --> False \n");
        // Down
        if (InputManager.Button_DPad_Down_Down()) Debug.LogFormat("Button_DPad_Down --> True \n");
        if (InputManager.Button_DPad_Down_Up()) Debug.LogFormat("Button_DPad_Down --> False \n");

        #endregion DPad

        #endregion Buttons

        #region Axis

        #region Right/Left-Stick.Vector3
        if (InputManager.Button_Cross_Down())
        {
            Debug.LogFormat("RightStick.Vector3 --> " + InputManager.Joystick_RightStick() + " \n");
            Debug.Log("LeftStick.Vector3 --> " + InputManager.Joystick_LeftStick() + "\n");
        }
        #endregion Right/Left-Stick.Vector3

        #region Left/Right-Stick.IsDeadZone
        if (InputManager.Button_Square_Down())
        {
            Debug.LogFormat("LeftStick_Horizontal.IsDeadZone --> " + InputManager.LeftStick_Horizontal_IsDeadZone() + "\n");
            Debug.LogFormat("LeftStick_Vertical.IsDeadZone --> " + InputManager.LeftStick_Vertical_IsDeadZone() + "\n");
            Debug.LogFormat("RightStick_Horizontal.IsDeadZone --> " + InputManager.RightStick_Horizontal_IsDeadZone() + "\n");
            Debug.LogFormat("RightStick_Vertical.IsDeadZone --> " + InputManager.RightStick_Vertical_IsDeadZone() + "\n");
        }
        #endregion Left/Right-Stick.IsDeadZone

        #region Right/Left-Trigger.Vector3
        if (InputManager.Button_LeftBumper_Down())
        {
            Debug.LogFormat("RightTrigger.Vector3 --> " + InputManager.Trigger_Right() + " \n");
            Debug.Log("LeftTrigger.Vector3 --> " + InputManager.Trigger_Left() + "\n");
        }
        #endregion Right/Left-Trigger.Vector3

        #region Left/Right-Trigger.IsDeadZone
        if (InputManager.Button_RightBumper_Down())
        {
            Debug.LogFormat("RightTrigger.IsDeadZone --> " + InputManager.Trigger_Right_IsDeadZone() + " \n");
            Debug.Log("LeftTrigger.IsDeadZone --> " + InputManager.Trigger_Left_IsDeadZone() + "\n");
        }
        #endregion Left/Right-Trigger.IsDeadZone

        #region DPad
        

        #region DPad.Vector3
        if (InputManager.Button_Circle_Down())
        {
            Debug.LogFormat("DPad.Vector3 --> " + InputManager.DPad() + " \n");
            Debug.Log("DPad.IsDeadZone --> " + InputManager.DPad_IsDeadZone() + "\n");
        }
        #endregion DPad.Vector3
        #endregion DPad

        #endregion Axis
    }
}
