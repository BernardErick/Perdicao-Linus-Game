using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaperScript : MonoBehaviour
{
    public RawImage paper_raw_image;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jogador"))
            this.paper_raw_image.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
            this.paper_raw_image.enabled = false;
    }
}
