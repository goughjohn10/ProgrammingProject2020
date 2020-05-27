using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDirector : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Brief");
    }

    public void Continue()
    {
        SceneManager.LoadScene("City");
    }
}
