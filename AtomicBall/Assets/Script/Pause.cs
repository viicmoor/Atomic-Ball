using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else 
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void UnPause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
