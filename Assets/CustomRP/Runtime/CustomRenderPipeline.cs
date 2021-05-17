using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
public class CustomRenderPipeline : RenderPipeline
{
    CameraRenderer m_cameraRenderer = new CameraRenderer();
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        if (null == cameras) return;
        foreach(var cam in cameras)
        {
            m_cameraRenderer.Render(context, cam);
        }
    }
}
