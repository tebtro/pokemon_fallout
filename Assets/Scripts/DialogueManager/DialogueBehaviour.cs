using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour {

    [Header("Dialogue")]
    public Dialogue dialogue;

    public void StartDialogue()
    {
        DialogueManager.Instance().StartDialogue(dialogue);
    }

    public void Update()
    {
        if (DialogueManager.Instance().IsActive)
        {
            if(InputManager.Button_Cross_Down() || InputManager.Button_Circle_Down())
            {
                DialogueManager.Instance().DisplayNextParagraph();
            }
        } else
        {
            if (InputManager.Button_Cross_Down())
            {
                StartDialogue();
                DialogueManager.Instance().IsActive = true;
            }
        }
        //check button pressed start dialogue
        //check collider player
    }

}
