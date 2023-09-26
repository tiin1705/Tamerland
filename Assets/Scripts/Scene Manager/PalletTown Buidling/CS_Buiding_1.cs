using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Buiding_1 : MonoBehaviour
{
    public string targetSceneName;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Main Player"))
        {
            Debug.Log("Va cham");

            SceneChange manager = FindObjectOfType<SceneChange>();
            if(manager != null )
            {
                manager.ChangeScene(targetSceneName);
            }    
        }
    }
}
