using System;
using UnityEngine;
using UnityEngine.Events;

namespace RAP.Scripts
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private int _collectables;
        private Camera _camera;

        private void Start()
        {
            _camera = gameObject.GetComponent<Camera>();
        }

        private void CollectablesPlus()
        {
            _collectables++;
        }

        private void CollectablesReset()
        {
            _collectables = 0;
        }
        private void Pick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;
            if (!hit.collider.gameObject.CompareTag("Pick Up") || !Input.GetKeyDown(KeyCode.E)) return;
            Destroy(hit.collider.gameObject);
            CollectablesPlus();
        }

        private void Update()
        {
            Pick();
        }
    }
}
