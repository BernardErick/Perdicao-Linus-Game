using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;        
    private Rigidbody2D body;
    private  Animator anim;
    private bool grounded;
    public static bool backing = false;
    private float jumpSpeed = 12;
    public AudioSource theme1;
    public AudioSource handTheme;
    public Image filter;
    
    private void Awake() {
        //Pegando as referências do rigidbody e do animator do objeto
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
        
    }

    private void Update() {
        if (WallMovement.hands) 
        {
            theme1.mute = true;
            handTheme.mute = false;
            filter.color = new Color32(0, 0, 0, 179);
    
        }
        else
        {
            theme1.mute = false;
            handTheme.mute = true;
            filter.color = new Color32(0, 0, 0, 0);
        }

            float horizontalInput = Input.GetAxis("Horizontal");

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            
            //Flipando o personagem 
            if (horizontalInput > 0)
            {
                backing = false;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            else if (horizontalInput < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                backing = true;
            }


            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                Jump();
            }
            //Configurando os parâmetros de animação 
            anim.SetBool("Running", horizontalInput != 0);
            anim.SetBool("Grounded", grounded);
       
    }

    private void Jump(){
        
        body.velocity = new Vector2(body.velocity.x,this.jumpSpeed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }

}
