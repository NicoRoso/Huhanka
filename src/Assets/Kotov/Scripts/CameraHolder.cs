using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private Transform player;
    void Update()
    {
        transform.position = cameraPos.position;
        transform.rotation = player.rotation;
    }
}
