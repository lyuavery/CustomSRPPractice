using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer
{
    ScriptableRenderContext m_context;
    Camera m_camera;
    const string BUFFER_NAME = "Render Buffer";
    CommandBuffer m_cmdBuf = new CommandBuffer() { name = BUFFER_NAME };
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        m_context = context;
        m_camera = camera;
        Setup();
        DrawVisibleGeometry();
        Submit();
    }

    void Setup()
    {
        m_cmdBuf.BeginSample(BUFFER_NAME);
        m_context.SetupCameraProperties(m_camera);
    }

    void DrawVisibleGeometry()
    {
        m_context.DrawSkybox(m_camera);
    }

    void Submit()
    {
        m_cmdBuf.EndSample(BUFFER_NAME);
        m_context.Submit();
    }
}
