using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class WallMovement : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private float velocity = 5;
    
    public float maxTime; 
    private float backwardTimer;
    public bool isBacking;
    public bool teste;
    public bool backOff;
    public static bool hands;
     
    
    

    private void Start()
    {
        this.backOff = false;
        this.isBacking = false;
    }

    private void Update()
    {
        if (isBacking == false && backOff == false && DeathZone.isDead == false && ItemCollector.isReading == false)
            MoveInDirection();
        else if (backOff == true && DeathZone.isDead == false)
        {
            backOffMovement();
        }
        else if(isBacking == true && DeathZone.isDead == false)
        {
            backwardMovement();
        }
        else if(DeathZone.isDead == true )
        {
            transform.position = spawnPoint.position;
            
        }

        
    }

    private void MoveInDirection()
    {
        this.backwardTimer = 0;
        transform.position += new Vector3(this.velocity * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            hands = true;

            if(PlayerMovement.backing == true)
            {
                this.backOff = true;
            }
                else
                    {

                        this.velocity = 0;
                    }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            hands = false;
            this.backOff = false;
            isBacking = true;
          
        //this.velocity = this.velocity_temp
    }
    private void backwardMovement()
    {
        backwardTimer += Time.deltaTime;
 
        
        transform.position += new Vector3(this.velocity * Time.deltaTime, 0f, 0f);

        if (backwardTimer > maxTime)
        {
            this.velocity = 5;
            isBacking = false;
        }
    }
    private void backOffMovement()
    {
        this.velocity = -5;
        transform.position += new Vector3(this.velocity * Time.deltaTime, 0f, 0f);
    }
}
