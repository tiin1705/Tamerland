using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 0f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask buildingLayer;
    public LayerMask foregroundLayer;
    public LayerMask houseyardLayer;
    public LayerMask seaLayer;



    // Start is called before the first frame update


    // Update is called once per frame
    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;  

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var playerPos = transform.position;
                playerPos.x += input.x;
                playerPos.y += input.y;

                if (isWalkable(playerPos))
                    StartCoroutine(Move(playerPos));
                  
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    IEnumerator Move(Vector3 playerPos)
    {
        isMoving = true;
        while((playerPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
            yield return null;
           
        }
        transform.position = playerPos;
        isMoving = false;
    }
    private bool buidingCheck(Vector3 playerPos)
    {
        //building layer check
        if(Physics2D.OverlapCircle(playerPos, 0.05f, buildingLayer) != null)
        {
            return false;
        }
        return true;
      
    }

    private bool foregroundCheck(Vector3 playerPos)
    {
        //foreground layer check
        if (Physics2D.OverlapCircle(playerPos, 0.05f, foregroundLayer) != null)
        {
            return false;
        }
        return true;
    }
   
    private bool houseyardCheck(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0.05f, houseyardLayer) != null)
        {
            return false;
        }
        return true;
    }

    private bool seaCheck(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0.05f, seaLayer) != null)
        {
            return false;
        }
        return true;
    }


    private bool isWalkable(Vector3 playerPos)
    {
        if (buidingCheck(playerPos) & foregroundCheck(playerPos) & houseyardCheck(playerPos) & seaCheck(playerPos))
        {
            return true;
        }
        return false ;
    }

}
