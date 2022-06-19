using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventController : MonoBehaviour
{
    public GameObject Player;
    public Canvas Player_Canvas;
    public Image DialogImage;
    public string FilePath;
    public bool flag = true;
    public Image temp;
    public int NumberOfSentences;
    public GameObject Monster;
    public bool unique = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false && temp == null && unique) {
            Debug.Log("Corre muleque");
            this.Player.GetComponent<PlayerController>().can_walk = true;
            this.Monster.active = true;
            this.unique = false;
            this.Player.GetComponent<PlayerController>().dialogs++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador")) {
            if (flag)
            {
                this.Player.GetComponent<PlayerController>().can_walk = false;
                this.DialogImage.GetComponent<InteractiveLabelAction>().FilePath = this.FilePath;
                this.DialogImage.GetComponent<InteractiveLabelAction>().NumberOfSentences = this.NumberOfSentences;
                this.temp = Instantiate(DialogImage, this.Player_Canvas.transform);
                flag = false;
                Debug.Log("Pronto criei");
            }
        }
    }
}
