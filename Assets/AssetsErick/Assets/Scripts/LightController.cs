using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LightController : MonoBehaviour
{
    public float velocityLight = 0.3f;
    private int LightZ = 0;
    public GameObject Warning;
    public GameObject Player;

    void Start()
    {
        StartCoroutine(LightRotateTime());
    }

    // Update is called once per frame
    void Update()
    {
        movementLight();
    }
    public IEnumerator LightRotateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            int randZ = Random.Range(-360, 360);
            Debug.Log("Random: " + randZ);
            this.LightZ = randZ;
        }
    }
    void movementLight()
    {
        Quaternion rotacaoAtual = this.transform.rotation;
        Quaternion rotacaoFinal = Quaternion.Euler(0, 0, this.LightZ);
        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoFinal, Time.fixedDeltaTime * velocityLight);
        this.transform.rotation = novaRotacao;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador")) {
            Debug.Log("Jogador capturado!");
            if (!collision.GetComponent<PlayerController>().invulnerable) {
                this.Warning.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                SceneManager.LoadScene("GameOver");
            }
            else
                Debug.Log("Spyman não pode fazer nada. Motivo: Jogador está invulneravel!");         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
        {
            Debug.Log("Jogador fugiu!");
            this.Warning.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}
