using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedderFog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<TimeDeath>().StartTimer(false, 0f);
            // RenderSettings.fogColor = new Color(0.5f, 0.5f, 0.5f, 1f);
            // RenderSettings.fogDensity = 0.04f;
            // RenderSettings.fogMode = FogMode.ExponentialSquared;
        }
    }
}
