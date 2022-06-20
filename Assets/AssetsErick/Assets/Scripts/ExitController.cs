using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitController : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public AudioSource audiosource;
    public AudioSource audioSource2;
    public bool change;

    public Text Canvas_Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.change) {
            SceneManager.LoadScene("Dissociation");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador")) {
            int dialogs = this.player.GetComponent<PlayerController>().dialogs;
            if (dialogs >= 5)
            {
                audioSource2.Play();
                this.monster.SetActive(true);
                audiosource.Play();
                StartCoroutine(ChangeRoutine());
            }
            else {
                StartCoroutine(TextRoutine());
                Debug.Log("Você não pode concluir a fase, restam "+ (5 - dialogs) + " diálogos.");
            }
        }
    }
    private IEnumerator ChangeRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        this.change = true;
    }
    private IEnumerator TextRoutine() {
        int dialogs = this.player.GetComponent<PlayerController>().dialogs;
        this.Canvas_Text.text = "Você não pode concluir a fase, restam " + (5 - dialogs) + " diálogos.";
        yield return new WaitForSeconds(2.0f);
        this.Canvas_Text.text = "";
    }
}
