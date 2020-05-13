using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRecursion : MonoBehaviour
{
    public int recurse;
    public GameObject leaves;
    public int splitNumber;
    private Vector3 leavesStart;
    
    void Start()
    {
        recurse -= 1;
        for (int i = 0; i < splitNumber; ++i)
        {
            if (recurse > 0)
            {
                var copy = Instantiate(gameObject);
                var recursive = copy.GetComponent<TreeRecursion>();
                recursive.SendMessage("Generated", i); //recursive = new one 
                leavesStart = copy.transform.position;
                Instantiate(leaves, leavesStart, Quaternion.identity);
            }
            /*else if (recurse == 0)
            {
                Instantiate(leaves, leavesStart, Quaternion.identity);
            }*/
        }
    }

}
