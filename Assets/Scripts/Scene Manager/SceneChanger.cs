using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName; // Tên của scene mới.
    public Vector3 newPlayerPosition; // Vị trí mới cho nhân vật.

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Main Player");
        if(player != null)
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
      
      

        // Chuyển scene.
        SceneManager.LoadScene(targetSceneName);
    }
}
