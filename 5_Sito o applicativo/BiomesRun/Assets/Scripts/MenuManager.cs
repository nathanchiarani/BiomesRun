using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    

    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
        mostraCursore();
    }

    public void LoadBiome1()
    {
        SceneManager.LoadScene(1);
        mostraCursore();
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(2);
        mostraCursore();
    }

    public void LoadBiome2()
    {
        SceneManager.LoadScene(3);
        mostraCursore();
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(4);
        mostraCursore();
    }

    public void LoadBiome3()
    {
        SceneManager.LoadScene(5);
        mostraCursore();
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(6);
        mostraCursore();
    }

    public void Victory()
    {
        SceneManager.LoadScene(7);
        mostraCursore();
    }

    public void LoseKey()
    {
        SceneManager.LoadScene(8);
        mostraCursore();
    }

    public void LoseLives()
    {
        SceneManager.LoadScene(9);
        mostraCursore();
    }
    private void Start()
    {
        
    }

    private void mostraCursore()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
