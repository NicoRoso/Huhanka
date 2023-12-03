using System;
using UnityEngine;

namespace RAP.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private Transform orientation;

        [SerializeField] private float _sensX, _sensY;
        [SerializeField] private float _xRotation, _yRotation;
        private Camera _camera;

        private void Start()
        {
            _camera = gameObject.GetComponent<Camera>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

            _yRotation += mouseX;

            _xRotation -= mouseY;
            _xRotation = Math.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            orientation.localRotation = Quaternion.Euler(0, _yRotation, 0);
        }
        void OnGUI()
        {
            int n = 12;
            float xxx = _camera.pixelWidth / 2 - n / 2;
            float yyy = _camera.pixelHeight / 2 - n / 2;
            GUI.Label(new Rect(xxx, yyy, n, n), "+");
        }
    }
}
