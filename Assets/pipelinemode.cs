using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class pipelinemode : MonoBehaviour
{
    public UniversalRenderPipelineAsset urp;
    void Start()
    {
        Debug.Log("Padrão:"+ urp.scriptableRenderer.ToString());
    }

}
