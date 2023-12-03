using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressThis : MonoBehaviour
{
    [SerializeField]
    private GameObject _press;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _press.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }

}
