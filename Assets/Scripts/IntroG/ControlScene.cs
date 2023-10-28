using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    // public AudioClip sfxButton;

    private bool oneshotSfx;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if(!oneshotSfx)
            {
                // AudioSource.PlayClipAtPoint(sfxButton,Vector3.zero);
                Invoke("LoadScene",0.5f);
                oneshotSfx = true;
            }
        }
    }
    void LoadScene()
    {
      SceneManager.LoadScene(1);
    }
}
