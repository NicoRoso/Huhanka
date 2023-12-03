using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<TimeDeath>().StartTimer(true, 80f);
            RenderSettings.fog = true; //C59A4B ColorRender
            RenderSettings.fogColor = new Color(0.772549f, 0.6039216f, 0.2941177f);
            
            RenderSettings.fogDensity = 0.03f;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
        }
    }
}
