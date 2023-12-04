using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FogToZero : MonoBehaviour
{
    [SerializeField] public bool entered=false;
    [SerializeField]private float coef;

    [SerializeField] private FogLoadUnloadScript revetable;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (entered)
        {
            float x = (float)(RenderSettings.fogDensity - Time.deltaTime * coef);
            if (x <= 0 ) 
            {
                RenderSettings.fogDensity = 0;
                // entered = false;
            }
            else RenderSettings.fogDensity = x;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
        RenderSettings.fogMode = FogMode.Exponential;
        if (revetable is not null)
        {
            revetable.FirstExit = false;
        }
    }
}
