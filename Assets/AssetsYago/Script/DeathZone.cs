using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
    public static bool isDead;
    [SerializeField] Transform spawnPoint;
    private void Start()
    {
        isDead = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))

            isDead = true;
            collision.transform.position = spawnPoint.position;

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            isDead = false;
    }
}
