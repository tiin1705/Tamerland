using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public string targetSceneName;

    public void ReturnToPreviousScene()
    {
        // Đặt lại vị trí của nhân vật tại vị trí đã lưu trước đó.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerScript playerController = player.GetComponent<PlayerScript>();
            if (playerController != null)
            {
                playerController.RestorePlayerPosition();
            }
        }

        // Load scene trước đó hoặc thực hiện bất kỳ logic quay lại nào bạn cần.
        // SceneManager.LoadScene("Tên của scene trước đó");
        SceneManager.LoadScene(targetSceneName);

    }
}
