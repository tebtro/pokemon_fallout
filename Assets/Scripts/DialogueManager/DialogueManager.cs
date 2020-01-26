using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region Singleton
    private static DialogueManager _Instance = null;

    protected DialogueManager()
    {

    }

    private void Awake()
    {
        if(_Instance == null) _Instance = this;
    }

    public static DialogueManager Instance()
    {
        return _Instance;
    }
    #endregion Singleton

    #region variables
    public Text text_NPC_Name;
    public Text text_Dialogue;
    public Animator animator;

    private Queue<string> paragraphs;

    private bool isActive;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    #endregion variables

    public void Start () {
        paragraphs = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool(Constants.DIALOGUE_ISOPEN, true);

        text_NPC_Name.text = dialogue.name;

        paragraphs.Clear();

        foreach (string paragraph in dialogue.pragraphs)
        {
            paragraphs.Enqueue(paragraph);
        }

        DisplayNextParagraph();
    }

    public void DisplayNextParagraph()
    {
        if (paragraphs.Count == 0)
        {
            EndDialogue();
            return;
        } else
        {
            string paragraph = paragraphs.Dequeue();
            StopAllCoroutines();
            StartCoroutine(WriteParagraph(paragraph));
        }
    }

    private IEnumerator WriteParagraph (string paragraph)
    {
        text_Dialogue.text = "";
        foreach(char letter in paragraph.ToCharArray())
        {
            text_Dialogue.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool(Constants.DIALOGUE_ISOPEN, false);
        IsActive = false;
    }
}
