using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public string targetSceneName; // Tên của scene mới.
    PlayerScript player;
    public Vector3 AfterChangeScenePosition;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Main Player")){
            StartCoroutine(SwitchScene());
        }
    }
    IEnumerator SwitchScene()
    {
       yield return SceneManager.LoadSceneAsync(targetSceneName);
        player.transform.position = AfterChangeScenePosition;
        Destroy(gameObject);
    }
    public Transform SpawnPoint => spawnPoint;
}
