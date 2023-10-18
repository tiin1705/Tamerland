
using UnityEngine;
[System.Serializable]
public class Response 
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;

    public string RresponseText => responseText;

    public  DialogueObject DialogueObject => dialogueObject;
}
