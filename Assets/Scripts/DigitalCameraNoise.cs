using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System;

[Serializable, VolumeComponentMenu("Post-processing/Custom/DigitalCameraNoise")]
public sealed class DigitalCameraNoise : CustomPostProcessVolumeComponent, IPostProcessComponent
{
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter intensity = new(0f, 0f, 1f);
    public ClampedFloatParameter darkCurrent = new(0f, 0f, 20f); //dark current: 8 mV/s
    public ClampedFloatParameter readNoise = new(0f, 0f, 4f); //TODO Not sure about this RMS?

    Material m_Material;

    public bool IsActive() => m_Material != null && intensity.value > 0f;

    // Do not forget to add this post process in the Custom Post Process Orders list (Project Settings > Graphics > HDRP Global Settings).
    public override CustomPostProcessInjectionPoint injectionPoint => CustomPostProcessInjectionPoint.AfterPostProcess;

    const string kShaderName = "Hidden/Shader/DigitalCameraNoise";

    public override void Setup()
    {
        if (Shader.Find(kShaderName) != null)
            m_Material = new Material(Shader.Find(kShaderName));
        else
            Debug.LogError($"Unable to find shader '{kShaderName}'. Post Process Volume DigitalCameraNoise is unable to load.");
    }

    public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
    {
        if (m_Material == null)
            return;

        m_Material.SetFloat("_Intensity", intensity.value);
        m_Material.SetFloat("_DarkCurrent", darkCurrent.value);
        m_Material.SetFloat("_ReadNoise", readNoise.value);
        m_Material.SetTexture("_MainTex", source);
        HDUtils.DrawFullScreen(cmd, m_Material, destination, shaderPassId: 0);
    }
    
    public override void Cleanup()
    {
        CoreUtils.Destroy(m_Material);
    }
}
