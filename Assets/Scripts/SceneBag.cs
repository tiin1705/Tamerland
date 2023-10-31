using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBag : MonoBehaviour
{
    public void SceneBagg()
    {
        SceneManager.LoadScene(2);
    }
    public void Close()
    {
        SceneManager.LoadScene(0);
    }
    public void Profile()
    {
        SceneManager.LoadScene(1);
    }
}
