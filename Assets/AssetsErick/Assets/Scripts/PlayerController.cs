using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public Rigidbody2D rigidbody2D;
    public bool is_C_pressed;
    public bool can_walk;
    public bool invulnerable;
    public Animator animator;
    public int dialogs;
    public Text CanvasText;

    void Start()
    {
        StartCoroutine(FraseInicial());
    }
    private IEnumerator FraseInicial() {
        yield return new WaitForSeconds(0.5f);
        this.CanvasText.text = "Voc� n�o sair� t�o f�cil hoje Linus.";
        yield return new WaitForSeconds(2.5f);
        this.CanvasText.text = "Sou parte de voc� agora.";
        yield return new WaitForSeconds(2.0f);
        this.CanvasText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        movement_controller();
        action_player();
    }
    void movement_controller() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (can_walk)
        {
            this.rigidbody2D.velocity = new Vector2(horizontal, vertical) * velocity;
            //this.rigidbody2D.transform.Translate(new Vector2(horizontal, vertical) * velocity * Time.deltaTime);
            this.animation_controller(horizontal, vertical);
        }
        else {
            this.rigidbody2D.velocity = new Vector2(0,0);
            animation_controller(0, 0);
        }
            
    }
    void action_player() {
        this.is_C_pressed = Input.GetKeyDown(KeyCode.C);
    }
    void animation_controller(float horizontal, float vertical) {
        if (horizontal < 0 || horizontal > 0)
        {
            animator.Play("PlayerWalk_Horizontal");
            if (horizontal > 0)
                this.GetComponent<SpriteRenderer>().flipX = true;
            if (horizontal < 0)
                this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (vertical < 0 || vertical > 0) 
        {
            if (vertical > 0) {
                animator.Play("PlayerWalk_Up");
            }
            if (vertical < 0) {
                animator.Play("PlayerWalk_Down");
            }
        }
        else
        {
            animator.Play("PlayerIdle");
        }
    }
}
