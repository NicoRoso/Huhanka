using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogToZero : MonoBehaviour
{
    [SerializeField] private bool entered=false;
    [SerializeField]private float coef;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (entered)
        {
            float x = (float)(RenderSettings.fogDensity - Time.deltaTime *coef);
            if (x <= 0 ) {RenderSettings.fog = false;
                enabled = false;
            }
            else RenderSettings.fogDensity = x;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
        RenderSettings.fogMode = FogMode.Exponential;
    }
}
