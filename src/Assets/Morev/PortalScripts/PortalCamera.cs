using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] Transform _playerCamera;
    [SerializeField] Transform _renderedPortal;
    [SerializeField] Transform _nearPlayerPortal;
    void LateUpdate()
    {
        // рабочая версия для поворота по одной оси
        //Vector3 playerOffsetFromPortal = _playerCamera.position - _nearPlayerPortal.position;
        //float angularDifference = _renderedPortal.eulerAngles.y - _nearPlayerPortal.eulerAngles.y;
        //Quaternion portalRotDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        //Vector3 newCamDir = portalRotDifference * _playerCamera.forward;
        //transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
        //transform.position = _renderedPortal.position + portalRotDifference * playerOffsetFromPortal;



        // версия работы по 3 осям (1 ось за раз)
        //Vector3 playerOffsetFromPortal = _playerCamera.position - _nearPlayerPortal.position;
        //float XangularDifference = -_nearPlayerPortal.eulerAngles.x;
        //float YangularDifference = -_nearPlayerPortal.eulerAngles.y;
        //float ZangularDifference = -_nearPlayerPortal.eulerAngles.z;
        //Quaternion angularDifference = Quaternion.Euler(XangularDifference, YangularDifference, ZangularDifference);
        //transform.localPosition = angularDifference * playerOffsetFromPortal;
        //transform.localRotation = angularDifference * _playerCamera.rotation;



        // актуальная версия
        Vector3 playerOffsetFromPortal = _playerCamera.position - _nearPlayerPortal.position;
        float XangularDifference = _nearPlayerPortal.rotation.x;
        float YangularDifference = _nearPlayerPortal.rotation.y;
        float ZangularDifference = _nearPlayerPortal.rotation.z;
        float WangularDifference = _nearPlayerPortal.rotation.w;
        Quaternion angularDifference = new Quaternion(XangularDifference,YangularDifference,ZangularDifference, WangularDifference);
        angularDifference = Quaternion.Inverse(angularDifference);
        transform.localPosition = angularDifference * playerOffsetFromPortal;
        transform.localRotation = angularDifference * _playerCamera.rotation;
    }
}