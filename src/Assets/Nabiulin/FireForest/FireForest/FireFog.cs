using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFog : MonoBehaviour
{
    [SerializeField]
    private GameObject _O2;
    [SerializeField]
    private GameObject _snow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _O2.SetActive(true);
            _snow.SetActive(false);
            other.gameObject.GetComponent<TimeDeath>().StartTimer(true, 80f);
            // RenderSettings.fog = true; //C59A4B ColorRender
            // RenderSettings.fogColor = new Color(0.772549f, 0.6039216f, 0.2941177f);
            //
            // RenderSettings.fogDensity = 0.03f;
            // RenderSettings.fogMode = FogMode.ExponentialSquared;
        }
    }
}
