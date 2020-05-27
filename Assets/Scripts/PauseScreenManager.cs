using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gun;
    public GameObject tipsScreen;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    // PauseScreen Elements
    #region U.I. Methods

    void PauseGame()
    {
        gun.SetActive(false);
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        gun.SetActive(true);
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Tips()
    {
        tipsScreen.SetActive(true);
    }

    public void TipsBack()
    {
        tipsScreen.SetActive(false);
    }

    public void StartOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Brief");
    }

    #endregion 
    


}
