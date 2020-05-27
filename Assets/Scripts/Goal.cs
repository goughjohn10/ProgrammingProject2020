using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && ScoringSystem.hasCollected)
        {
            EndGame();
            ScoringSystem.hasCollected = false;
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("PyramidExplode");
        PyramidFractal.leftScene = true;
        Debug.Log("Level Passed");
    }
}
