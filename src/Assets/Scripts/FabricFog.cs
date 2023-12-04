using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricFog : MonoBehaviour
{
    [SerializeField] private GameObject Blizard;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<TimeDeath>().StartTimer(false, 0f);
            RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
            RenderSettings.fogDensity = 0.025f;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            Blizard.SetActive(false);
        }
    }
}
