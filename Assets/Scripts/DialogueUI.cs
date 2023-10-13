using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private Typewirtereffect typewirtereffect;
    
    private void Start()
    {
      CloseDialogueBox();
      typewirtereffect = GetComponent<Typewirtereffect>();
      ShowDialogue(testDialogue);
    }
   
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThoughDialogue(dialogueObject));
    }

   private IEnumerator StepThoughDialogue(DialogueObject dialogueObject)
   {    
        yield return  new WaitForSeconds(2);
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return typewirtereffect.Run(dialogue, textLabel);
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
        }
        CloseDialogueBox();

   }

   private void CloseDialogueBox()
   {
     dialogueBox.SetActive(false);
     textLabel.text = string.Empty;
   }    
}
