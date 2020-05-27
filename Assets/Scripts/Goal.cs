using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && ScoringSystem.hasCollected)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("PyramidExplode");
        PyramidFractal.leftScene = true;
        Debug.Log("Level Passed");
    }
}
