using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public string targetSceneName; // Tên của scene mới.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene()
    {
        PlayerScript player = GetComponent<PlayerScript>();
       yield return SceneManager.LoadSceneAsync(targetSceneName);
       var destPortal =  FindObjectsOfType<Portal>().First(x => x != this);
        player.transform.position = destPortal.SpawnPoint.position;

    }
    public Transform SpawnPoint => spawnPoint;
}
