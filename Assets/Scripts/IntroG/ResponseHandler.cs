using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseHandler : MonoBehaviour
{
   [SerializeField] private RectTransform responseBox;
   [SerializeField] private RectTransform responseButtonTemplate;
   [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;
    private ResponseEvent[] responseEvents;
    public GameObject perSon;
   

   private List<GameObject> tempResponsesButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>(); 
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents;
       
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        for (int i = 0; i < responses.Length; i++)
        {   
            Response response = responses[i];
            int responseIndex = i;
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response,responseIndex));

            tempResponsesButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new  Vector2 ( responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
        
    }

    private void  OnPickedResponse(Response response, int responseIndex)
    {
        responseBox.gameObject.SetActive(false);
        perSon.SetActive(false); 
       

        

        foreach(GameObject button in tempResponsesButtons)
        {
            Destroy(button);
        }
        tempResponsesButtons.Clear();

        if(responseEvents != null && responseIndex <= responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
            
            
        }

        dialogueUI.ShowDialogue(response.DialogueObject);
    }
}