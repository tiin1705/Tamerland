using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Buiding_1 : MonoBehaviour
{
    public string targetSceneName;
    public Vector3 newPosition; // Vị trí mới cho nhân vật sau khi chuyển scene.

    public void OnTriggerEnter2D(Collider2D collision)
    {  // Lưu vị trí hiện tại của nhân vật trước khi chuyển scene.
        GameObject player = GameObject.FindGameObjectWithTag("Main Player");
        if (player != null)
        {
            PlayerScript playerController = player.GetComponent<PlayerScript>();
            if (playerController != null)
            {
                playerController.SavePlayerPosition();
            }
        }
      


        // Chuyển scene.

        SceneManager.LoadScene(targetSceneName);
    }
}
