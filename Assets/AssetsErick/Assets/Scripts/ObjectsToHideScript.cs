using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToHideScript : MonoBehaviour
{
    public bool player_inside;
    public Collider2D player;
    public bool player_want_exit;
    public GameObject btnWarning;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    void Action() {

        if (this.player == null)
            return;
        bool is_c_pressed = this.player.GetComponent<PlayerController>().is_C_pressed;

        if (is_c_pressed)
        {
            Debug.Log("Opa o jogador apertou C dentro da minha area");
            this.player_want_exit = !this.player_want_exit;
        }
        else 
            return;
        if (this.player_want_exit)
        {
            Debug.Log("Jogador pediu para sair");
            this.player.GetComponent<PlayerController>().can_walk = true;
            this.player.GetComponent<PlayerController>().invulnerable = false;
            this.player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        else {
            Debug.Log("Jogador pediu para entrar");
            this.player.GetComponent<PlayerController>().can_walk = false;
            this.player.GetComponent<PlayerController>().invulnerable = true;
            this.player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador")) {
            this.player_inside = true;
            this.player = collision;
            this.btnWarning.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
        {
            this.player_inside = false;
            this.player = null;
            this.btnWarning.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}
