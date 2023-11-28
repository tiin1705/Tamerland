using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 0f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask buildingLayer;
    public LayerMask foregroundLayer;
    public LayerMask seaLayer;
    public GameObject Menu;

    private Vector3 newPosition; // Biến để lưu trữ vị trí mới của nhân vật.
    private Vector3 currentPos;


    private static PlayerScript instance;
    public static PlayerScript Instance
    {
        // Tạo một getter để lấy phiên bản duy nhất của PlayerController.

        get { return instance; }
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
                playerPos.x += input.x*0.5f;
                playerPos.y += input.y*0.5f;

                if (isWalkable(playerPos))
                    StartCoroutine(Move(playerPos));
                  
            }
        }
        animator.SetBool("isMoving", isMoving);
        if(Input.GetKeyDown(KeyCode.P))
        {
           Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    IEnumerator Move(Vector3 playerPos)
    {
        isMoving = true;
        while((playerPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, playerPos, 0.5f);
            transform.position = Vector3.MoveTowards(transform.position,newPosition, moveSpeed * Time.deltaTime);
            yield return null;
           
        }
        transform.position = playerPos;
        isMoving = false;
    }

    private void Start()
    {
        transform.position = currentPos;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Nếu đã tồn tại một phiên bản khác, hủy bỏ phiên bản hiện tại.
            Destroy(gameObject);
        }



    }
  
    

   


    private bool buidingCheck(Vector3 playerPos)
    {
        //building layer check
        if(Physics2D.OverlapCircle(playerPos,0.01f,buildingLayer) != null)
        {
            Debug.Log("Va cham building");
            return false;
        }
        return true;
      
    }

    private bool foregroundCheck(Vector3 playerPos)
    {
        //foreground layer check
        if (Physics2D.OverlapCircle(playerPos, 0.01f, foregroundLayer) != null)
        {
            Debug.Log("Va cham foreground");
            return false;
        }
        return true;
    }
   
   

    private bool seaCheck(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0.01f, seaLayer) != null)
        {
            Debug.Log("Va cham sea");
            return false;
        }
        return true;
    }


    private bool isWalkable(Vector3 playerPos)
    {
        if (foregroundCheck(playerPos) && buidingCheck(playerPos) && seaCheck(playerPos))
        {
            return true;
        }
        return false ;
    }
   

}
