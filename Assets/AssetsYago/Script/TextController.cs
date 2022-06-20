using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ItemCollector.paperCount == 1 && ItemCollector.isReading == true) 
        {
          //  Transform child = transform.Find("Text1");
           // Text text = child.GetComponent<Text>();
            //text.enabled = true;
        }
       
    }
    
}
