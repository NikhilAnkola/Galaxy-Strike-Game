using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;        // an array to store all the dialogues 
    [SerializeField] TMP_Text dialogueText;             // here we'll drag our Dialogue Text created in UI Canvas

    int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine++;      // increments the dialogues 
        dialogueText.text = timelineTextLines[currentLine];     // this will print the dialogue of the current voice line 
    }
}
