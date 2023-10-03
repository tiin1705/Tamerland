using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerScript : MonoBehaviour
{
    private Vector3 CurrentPos; //biến lưu vị trí hiện tại của nhân vật
    public float moveSpeed = 0f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask buildingLayer;
    public LayerMask foregroundLayer;
    public LayerMask seaLayer;
    private static PlayerScript instance;

    // Tạo một getter để lấy phiên bản duy nhất của PlayerScript.

    public static PlayerScript Instance
    {
        get { return instance; }
    }




    // Start is called before the first frame update


    // Update is called once per frame
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

    private void Start()
    {
        // Lưu vị trí hiện tại của nhân vật khi bắt đầu scene.
        CurrentPos= transform.position;
    }
    public void SavePlayerPosition()
    {
        //Lưu vị trí hiện tại của nhân vật vào biến
        CurrentPos = transform.position;
    }
    public void RestorePlayerPosition()
    {
        // Đặt lại vị trí của nhân vật tại vị trí đã lưu trước đó.
        transform.position = CurrentPos;
    }


    private bool buidingCheck(Vector3 playerPos)
    {
        //building layer check
        if(Physics2D.OverlapCircle(playerPos,0f,buildingLayer) != null)
        {
            return false;
        }
        return true;
      
    }

    private bool foregroundCheck(Vector3 playerPos)
    {
        //foreground layer check
        if (Physics2D.OverlapCircle(playerPos, 0f, foregroundLayer) != null)
        {
            return false;
        }
        return true;
    }
   
   

    private bool seaCheck(Vector3 playerPos)
    {
        if (Physics2D.OverlapCircle(playerPos, 0f, seaLayer) != null)
        {
            return false;
        }
        return true;
    }


    private bool isWalkable(Vector3 playerPos)
    {
        if (buidingCheck(playerPos) & foregroundCheck(playerPos)  & seaCheck(playerPos))
        {
            return true;
        }
        return false ;
    }
   

}
