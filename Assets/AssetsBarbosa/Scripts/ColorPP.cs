using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;


public class ColorPP : MonoBehaviour
{ 
    //public PostProcessVolume _postProcessVolume;

    [SerializeField]
    public Gradient gradient;
    public float duration;
    float t = 0f;
    public bool addFog = false;
    // Start is called before the first frame update
    void Start()
    {
        Color color = gradient.Evaluate(0f);
        RenderSettings.fogColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (addFog == true)
        {
            float value = Mathf.Lerp(0f, 1f, t);
            t += Time.deltaTime / duration;
            Color color = gradient.Evaluate(value);
            RenderSettings.fogColor = color;
        }
        
    }
}
