using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    public GameObject contClick;
    private Typewirtereffect typewirtereffect;
    
    private void Start()
    {
      CloseDialogueBox();
      typewirtereffect = GetComponent<Typewirtereffect>();
      ShowDialogue(testDialogue);
      contClick.SetActive(false); 
      dialogueBox.SetActive(false);
     
    }
   
    public void ShowDialogue(DialogueObject dialogueObject, List<string>choices=null )
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThoughDialogue(dialogueObject));
    }

   private IEnumerator StepThoughDialogue(DialogueObject dialogueObject)
   {    
        yield return new WaitForSeconds(2);
         dialogueBox.SetActive(true);
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return typewirtereffect.Run(dialogue, textLabel);
            contClick.SetActive(true); 
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
            contClick.SetActive(false); 
        }
        CloseDialogueBox();

   }

   private void CloseDialogueBox()
   {
     dialogueBox.SetActive(false);
     textLabel.text = string.Empty;
   }    
}
