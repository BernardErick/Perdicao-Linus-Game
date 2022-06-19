using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class setUrp : MonoBehaviour
{
    public UniversalRenderPipelineAsset qualityLevels;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(0);
        QualitySettings.renderPipeline = qualityLevels;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
