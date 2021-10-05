using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPassed = false;

    public GameObject pauseGameMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPassed)
            {
                Menu();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Menu()
    {
        pauseGameMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPassed = true;   
    }

    public  void Pause()
    {
        pauseGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPassed = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Application.Quit();
    }

    public void BackToGame()
    {
        pauseGameMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPassed = false;
    }
}
