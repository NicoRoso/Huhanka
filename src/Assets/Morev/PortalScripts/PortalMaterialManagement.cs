using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMaterialManagement : MonoBehaviour
{
    [SerializeField] Camera cameraB;
    [SerializeField] Camera cameraC;
    [SerializeField] Material cameraMaterialB;
    [SerializeField] Material cameraMaterialC;
    void Start()
    {
        if(cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height,24);
        cameraMaterialB.mainTexture = cameraB.targetTexture;

        if (cameraC.targetTexture != null)
        {
            cameraC.targetTexture.Release();
        }
        cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterialC.mainTexture = cameraC.targetTexture;
    }
}
