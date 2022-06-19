using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitController : MonoBehaviour
{
    public GameObject player;
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
            int dialogs = this.player.GetComponent<PlayerController>().dialogs;
            if (dialogs >= 5)
            {
                SceneManager.LoadScene("Dissociation");
            }
            else {
                Debug.Log("Você não pode concluir a fase, restam "+ (5 - dialogs) + " dialogos.");
            }
        }
    }
}
