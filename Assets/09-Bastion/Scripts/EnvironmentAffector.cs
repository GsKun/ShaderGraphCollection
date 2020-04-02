using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAffector : MonoBehaviour
{
    public Material[] mats;

    void Update()
    {
        foreach (Material m in mats)
        {
            m.SetVector("_PlayerPos", transform.position);
        }
    }
}
