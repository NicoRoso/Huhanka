using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMaterialManagement : MonoBehaviour
{
    // я допишу, чтобы каждую камеру находило и всё такое (Олег)
    [SerializeField] Camera cameraA;
    [SerializeField] Camera cameraB;
    [SerializeField] Material cameraMaterialA;
    [SerializeField] Material cameraMaterialB;
    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterialA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterialB.mainTexture = cameraB.targetTexture;
    }
}
