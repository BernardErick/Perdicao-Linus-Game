using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitgame : MonoBehaviour
{

    public GameObject canvas;
    private LevelChanger levelChanger;
    // Start is called before the first frame update
    void Start()
    {
        levelChanger = canvas.GetComponent<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return new WaitForSeconds(5);
            levelChanger.FadeToLevel(1);
            
            //Application.Quit();
        }

    }
}
