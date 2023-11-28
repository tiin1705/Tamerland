using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject continueBtn;
    internal Transform thisTransform;
    public bool isMoving;

    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.forward, Vector3.back, Vector3.zero, Vector3.zero };
    internal int currentMoveDirection;
    // Use this for initialization
    void Start()
    {
        // Cache the transform for quicker access
        thisTransform = this.transform;

        // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move the object in the chosen direction at the set speed
            thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

            if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
            else
            {
                // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
                decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

                // Choose a movement direction, or stay in place
                ChooseMoveDirection();
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            continueBtn.SetActive(true);
        }
    }
    public void nextLine()
    {
        continueBtn.SetActive(false);
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Main Player"))
        {
            playerIsClose = true;
            isMoving = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Main Player"))
        {
            playerIsClose = false;
            isMoving = true;
            zeroText();
        }
    }
    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}
