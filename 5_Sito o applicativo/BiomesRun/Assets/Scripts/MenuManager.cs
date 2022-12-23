using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    

    public void Exit() // es^ce dal gioco
    {
        Application.Quit();
    }

    public void ReturnMain() // carica la schermata di benvenuto
    {
        SceneManager.LoadScene(0);
        mostraCursore();
    }

    public void LoadBiome1() // carica la spiegazione del primo livello
    {
        SceneManager.LoadScene(1);
        mostraCursore();
    }

    public void StartLevel1() //carica il primo livello
    {
        SceneManager.LoadScene(2);
        mostraCursore();
    }

    public void LoadBiome2() // carica la spiegazione del secondo livello
    {
        SceneManager.LoadScene(3);
        mostraCursore();
    }

    public void StartLevel2() //carica il secondo livello
    {
        SceneManager.LoadScene(4);
        mostraCursore();
    }

    public void LoadBiome3() // carica la spiegazione del terzo livello
    {
        SceneManager.LoadScene(5);
        mostraCursore();
    }
    public void StartLevel3() //carica il terzo livello
    {
        SceneManager.LoadScene(6);
        mostraCursore();
    }

    public void Victory() //carica la schermata di vittoria
    {
        SceneManager.LoadScene(7);
        mostraCursore();
    }

    public void LoseKey() //carica la schermata di perdita per la chiave falsa
    {
        SceneManager.LoadScene(8);
        mostraCursore();
    }

    public void LoseLives() //carica la schermata di perdita per l'esaurimento delle vite
    {
        SceneManager.LoadScene(9);
        mostraCursore();
    }

    private void mostraCursore() // mostra il cursore per poter interagire con i bottoni
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
