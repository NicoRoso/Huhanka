using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricFog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
            RenderSettings.fogDensity = 0.025f;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
        }
    }
}
