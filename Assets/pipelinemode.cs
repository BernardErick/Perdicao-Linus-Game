using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class pipelinemode : MonoBehaviour
{
    public UniversalRenderPipelineAsset[] qualityLevels;
    void Start()
    {
       
    }
    void Update()
    {
        

    }

    public void changeUrp()
    {
        QualitySettings.SetQualityLevel(1);
        QualitySettings.renderPipeline = qualityLevels[1];


    }
}
