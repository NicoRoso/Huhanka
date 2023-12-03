using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PortalMaterialManagement : MonoBehaviour
{
    [SerializeField] List<CameraAndMaterial> camerasAndMaterials;
    void Start()
    {
        InitializeAllCameras();
    }
    void InitializeCamera(Camera cam, Material mat)
    {
        if (cam != null && cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat.mainTexture = cam.targetTexture;
    }
    void InitializeAllCameras()
    {
        foreach (CameraAndMaterial camAndMat in camerasAndMaterials)
        {
            InitializeCamera(camAndMat.camera, camAndMat.material);
        }
    }
}

[Serializable]
public class CameraAndMaterial
{
    public Camera camera;
    public Material material;
}
