using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [Header("GUI")]
    public GameObject pauseMenu;

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.active)
            {
                DefocusMenu();
            }
            else
            {
                FocusMenu();
            }   
        }
    }

    public void FocusMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DefocusMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
