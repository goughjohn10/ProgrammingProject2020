using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRecursionScale : MonoBehaviour
{
    public float scaler;
    public void Generated(int index)
    {
        this.transform.localScale *= scaler;
    }
}
