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
    }

    public void LoadBiome1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadBiome2()
    {
        SceneManager.LoadScene(3);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadBiome3()
    {
        SceneManager.LoadScene(5);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(6);
    }

    public void Victory()
    {
        SceneManager.LoadScene(7);
    }

    public void LoseKey()
    {
        SceneManager.LoadScene(8);
    }

    public void LoseLives()
    {
        SceneManager.LoadScene(9);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
