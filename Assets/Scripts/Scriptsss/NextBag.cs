using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBag : MonoBehaviour
{
    public GameObject Items;
    public GameObject KeyItemss;
    public GameObject PokeBalls;
    private int Selection;
    // bool dangoKeyItems= true;
    void Start()
    {
        Selection = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(Selection <=3)
            {
                Selection++;
            }
            if(Selection > 3)
            {
                Selection = 3;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if( Selection >= 1)
            {
                Selection--;
            }
            if(Selection < 1)
            {
                Selection = 1;
            }
        }
        if(Selection == 1)
        {
            Items.SetActive(true);
            KeyItemss.SetActive(false);
            PokeBalls.SetActive(false);
        }
        if(Selection == 2)
        {
            Items.SetActive(false);
            KeyItemss.SetActive(true);
            PokeBalls.SetActive(false);
        }
        if(Selection == 3)
        {
            Items.SetActive(false);
            KeyItemss.SetActive(false);
            PokeBalls.SetActive(true);
        }

        
        
        
    }
}
