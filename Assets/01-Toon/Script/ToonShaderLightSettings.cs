using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ToonShaderLightSettings : MonoBehaviour 
{
    private Light light;

    private void OnEnable()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        Shader.SetGlobalVector("_ToonLightDirection", -transform.forward);
        Shader.SetGlobalColor("_ToonColor", light.color);
    }
}