using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public RawImage rawimage;
    public float timer;
    public float maxTimer = 2;

    // Update is called once per frame
    void Update()
    {
        if (WallMovement.hands == true)
        {
            rawimage.enabled = true;
        }
        else
        {
           
            rawimage.enabled = false;
        }
            
    }
}
