using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Trig_Audio : MonoBehaviour
{
    bool addFog = false;
    bool isPlaying = false;
    public AudioSource m_MyAudioSource;
    public GameObject Player;
    public GameObject Child;
    private CharController CharController;

    public GameObject postProcess;
    private ColorPP colorPP;

    //public ColorPP colorPP;


   
    //int i = 0;

    private Vector3 _startPosition;

    void Awake()
    {
        CharController = Player.GetComponent<CharController>();
        colorPP = postProcess.GetComponent<ColorPP>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(addFog == true)
        {
            
            change_fog();
            

        }
     


        Debug.Log(RenderSettings.fogDensity);

    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player" && isPlaying == false)
        {
            CharController.canMove = false;
            m_MyAudioSource.Play();
            CharController.speed -= 0.8f;
            //change_fog();
            //Debug.Log(CharController.speed);
            isPlaying = true;
            addFog = true;
            Destroy(Child);
            colorPP.addFog = true;

            yield return new WaitForSeconds(7);
            addFog = false;
            colorPP.addFog = false;
            //isPlaying = false;
            CharController.canMove = true;

        }
        
    }
    private void change_fog()
    {
        RenderSettings.fogDensity += 0.01f * Time.deltaTime;
       
        //isPlaying = false;
        
    }
}
