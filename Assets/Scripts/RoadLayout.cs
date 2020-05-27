using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLayout : MonoBehaviour
{
    public GameObject road;
    public GameObject roadNoTrees;
    public Vector3 startPosition;
    public Vector3 offset; 
    private int recurse = 2;
    private int splitNumber = 2;
 
    void Start()
    {
        recurse -= 1;
        for (int i = 0; i < splitNumber; ++i)
        {
            if (recurse > 0)
            {
                Instantiate(road, startPosition, Quaternion.identity);
                Instantiate(road, startPosition + offset, Quaternion.identity);
                offset = new Vector3(5, 0, 0);
                var copy = Instantiate(road, startPosition + offset, Quaternion.identity);
                offset = new Vector3(5, 0, -10);
                Instantiate(road, startPosition + offset, Quaternion.identity);
                startPosition = copy.transform.position;
                Instantiate(road, startPosition + offset, Quaternion.identity);
                offset = new Vector3(5, 0, 0);
                Instantiate(road, startPosition + offset, Quaternion.identity);
                offset = new Vector3(5, 0, -10);
            }
        }
    }
}
