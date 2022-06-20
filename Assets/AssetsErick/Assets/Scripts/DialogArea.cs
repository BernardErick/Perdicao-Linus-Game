using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogArea : MonoBehaviour
{
    public Canvas canvas;
    public Image image;
    public GameObject player;
    public string FilePath;
    public bool flag = true;

    public int NumberOfSentences;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador")) {
            if (flag) {
                this.image.GetComponent<InteractiveLabelAction>().FilePath = this.FilePath;
                this.image.GetComponent<InteractiveLabelAction>().NumberOfSentences = this.NumberOfSentences;
                Instantiate(image, this.canvas.transform);
                flag = false;
            }
        }
    }
}
