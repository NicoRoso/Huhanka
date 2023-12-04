using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogLoadUnloadScript : MonoBehaviour
{
    [SerializeField] public bool FirstExit=false;
    [SerializeField] private bool colorSnap=false;
    [SerializeField]private float coef;
    
    [SerializeField]private Color fogColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    [SerializeField]private float fogColorChangeTime = 3f;
    [SerializeField]private float fogDensity = 0.04f;
    [SerializeField]private FogMode fogMode = FogMode.ExponentialSquared;
    
    
    [SerializeField] private FogToZero revetable;
    

    private void Start()
    {
        RenderSettings.fog = true;
    }

    void FixedUpdate()
    {
        if (FirstExit)
        {
            float x = (float)(RenderSettings.fogDensity + Time.deltaTime *coef);
            if (x >= fogDensity )
            {
                RenderSettings.fogDensity = fogDensity;
                // enabled = false;
            }
            else RenderSettings.fogDensity = x;
            if (!colorSnap)
            {
                if (fogColorChangeTime <= Time.deltaTime)
                {
                    // transition complete
                    // assign the target color
                    RenderSettings.fogColor = fogColor;
                    fogColorChangeTime = 1.0f;
                }
                else
                {
                    // transition in progress
                    // calculate interpolated color
                    RenderSettings.fogColor =
                        Color.Lerp(RenderSettings.fogColor, fogColor, Time.deltaTime / fogColorChangeTime);

                    // update the timer
                    fogColorChangeTime -= Time.deltaTime;
                }
            }
            else
            {
                RenderSettings.fogColor = fogColor;
            }


            // if (RenderSettings.fogDensity == fogDensity && fogColor == RenderSettings.fogColor)
            // {
            //     Destroy(gameObject);
            // }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirstExit = true;
        RenderSettings.fogMode = fogMode;
        if (revetable is not null)
        {
            revetable.entered = false;
        }
    }
}
