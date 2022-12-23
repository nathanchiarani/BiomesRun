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

        if (Input.GetKeyDown(KeyCode.Escape)) // se l'utente schiaccia esc
        {
            // se la schermata di pausa è presente la toglie e riparte il gioco, altrimenti la visualizza e ferma il gioco
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

    public void FocusMenu() // metodo che rende il cursore visibile e visualizza la schermata di pausa
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DefocusMenu() // metodo che rende il cursore invisibile e rimuove la schermata di pausa
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
