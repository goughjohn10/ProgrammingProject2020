using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public Animation swingAnim;

    public static bool isSwinging;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            swingAnim.Play();
        }
        
        if (swingAnim.isPlaying)
        {
            isSwinging = true;
        }
        else
        {
            isSwinging = false;
        }
    }
    
}
