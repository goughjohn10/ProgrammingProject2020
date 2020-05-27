using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    #region Fields

    public GameObject scoreText;
    public int theScore;
    public AudioSource collectSound;
    public Vector3[] collectablePoints;
    private bool loopRestart;
    public static bool hasCollected = false;
    public GameObject finishLine;
    public GameObject collectedText;
    public Animation collectedTextAnim;
    public GameObject beginText;

    #endregion
    
    #region Methods

    private void Start()
        {
            StartCoroutine(StartInstructs());
        }
    
    private IEnumerator StartInstructs()
    {
        beginText.GetComponent<Text>().text = "Walk into the artifact to pick it up";
        yield return new WaitForSeconds(2);
        beginText.GetComponent<Text>().text = "";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectSound.Play();
            theScore += 1;
            scoreText.GetComponent<Text>().text = "Artifacts: " + theScore +"/10";
            MoveCollectable(this.transform.position);
            //Debug.Log("Score");
        }
    }

    void MoveCollectable(Vector3 currentPosition)
    {
        if (!hasCollected)
        {
            
            if (currentPosition == collectablePoints[4])
            {
                //transform.position = collectablePoints[0]
                transform.SetPositionAndRotation(collectablePoints[0], Quaternion.identity); 
                loopRestart = true;
            }
            else if (currentPosition == collectablePoints[3])
            {
                transform.SetPositionAndRotation(collectablePoints[4], Quaternion.identity);
            }
            else if (currentPosition == collectablePoints[2])
            {
                transform.SetPositionAndRotation(collectablePoints[3], Quaternion.identity);
            }
            else if (currentPosition == collectablePoints[1])
            {
                transform.SetPositionAndRotation(collectablePoints[2], Quaternion.identity);
            }
            else if (currentPosition == collectablePoints[0] && loopRestart == false)
            {
                transform.SetPositionAndRotation(collectablePoints[1], Quaternion.identity);
            }

            loopRestart = false;
        }
        else if (hasCollected)
        {
            collectedTextAnim.Play();
            finishLine.gameObject.SetActive(true);
            scoreText.GetComponent<Text>().text = theScore + "/10";
            collectedText.GetComponent<Text>().text = "Go to the top of the pyramid";
            collectedTextAnim.Play();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (theScore > 8)
        {
            hasCollected = true;
        }

        if (theScore > 9)
        {
            /*
            collectedTextAnim.Play();
            finishLine.gameObject.SetActive(true);*/
        }
        else
        {
            collectedText.GetComponent<Text>().text = "";
        }
    }

    #endregion
    
}
