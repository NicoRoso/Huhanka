using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    [SerializeField] private bool entered=false;
    [SerializeField]private float coef;
    
    [SerializeField]private Color fogColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    [SerializeField]private float fogDensity = 0.04f;
    [SerializeField]private FogMode fogMode = FogMode.ExponentialSquared;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogMode = fogMode;
        RenderSettings.fog = true;
    }

    void FixedUpdate()
    {
        if (!entered)
        {
            float x = (float)(RenderSettings.fogDensity - Time.deltaTime * coef);
            if (x <= 0)
            {
                entered = false;
            }
            else RenderSettings.fogDensity = x;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!entered)
            {
                entered = true;
                RenderSettings.fogColor = fogColor;
            }
            else
            {
                entered = false;
            }
        }
    }
}
