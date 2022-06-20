using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpymanController : MonoBehaviour
{
    public ArrayList endpoints;
    private bool catchPlayer = false;
    private Vector3 position;
    public float slow;
    public GameObject player;
    public int tempo = 0;
    void Start()
    {
        StartCoroutine(AutoDestruction());
    }

    // Update is called once per frame
    void Update()
    {
        movementSpyman();
    }
    public IEnumerator AutoDestruction()
    {
        while (true) {
            yield return new WaitForSeconds(1.0f);
            this.tempo++;
            Debug.Log(this.tempo);
            if (this.tempo == 10) {
                Destroy(this.gameObject);
            }
        }
    }
    void movementSpyman()
    {
        Vector3 posicaoInicial = this.transform.position;
        Vector3 posicaoFinal = this.player.transform.position;
        Debug.Log(Time.fixedDeltaTime);
        this.transform.position = Vector3.Lerp(posicaoInicial, posicaoFinal, Time.fixedDeltaTime/slow);
    }
}
