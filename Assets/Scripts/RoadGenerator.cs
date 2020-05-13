using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public int recurse;
    public int splitNumber;
    public Vector3 rightOriginalOffset;
    public Vector3 leftOriginalOffset;
    public Vector3 offset;
    
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        GrowTrees(leftOriginalOffset);
        GrowTrees(rightOriginalOffset);
        
    }

    void GrowTrees(Vector3 startingOffset)
    {
        var firstPosition = (this.transform.position) + startingOffset;
        var trees = Instantiate(tree, firstPosition, Quaternion.identity);
        var midPosition = (trees.transform.position) + offset;
        var treesTwo = Instantiate(tree, midPosition, Quaternion.identity);
        var lastPosition = firstPosition - offset;
        var treesThree = Instantiate(tree, lastPosition, Quaternion.identity);
    }
}
