using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int paperCount;
    public static bool isReading = false;
    public bool isTaked = false; 
    public Image img ;
    public string msg;
    public Text txt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTaked) 
        {
            this.txt.text = msg;
            this.img.enabled = true;
            this.isTaked = true; 
            StartCoroutine(autoDestruction());
        }
        if (collision.gameObject.CompareTag("Paper")) 
        {
            isReading = true;
            paperCount++;
           

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            isReading = false;
        }
    }

    private  IEnumerator autoDestruction()
    {
        yield return new WaitForSeconds(15.0f);
        this.txt.text = "";
        this.img.enabled = false;
        this.GetComponent < SpriteRenderer >().enabled = false;
        isReading = false;
    }

}
