using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject _blizzard;

    [Header("HUD")]
    [SerializeField]
    private GameObject _O2;
    [SerializeField]
    private GameObject _snow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _blizzard.SetActive(true);
            _O2.SetActive(false);
            _snow.SetActive(true);
            other.gameObject.GetComponent<TimeDeath>().StartTimer(true, 120f);
            RenderSettings.fog = true; //808080 ColorRender
            RenderSettings.fogColor = new Color(0.5019608f, 0.5019608f, 0.5019608f);
            RenderSettings.fogDensity = 0.02f;
            RenderSettings.fogMode = FogMode.Exponential;
        }
    }
}
