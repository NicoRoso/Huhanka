using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _O2;
    [SerializeField]
    private GameObject _snow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _O2.SetActive(true);
            _snow.SetActive(false);
            other.gameObject.GetComponent<EndScreen>().StartTimerToEnd(true, 80f);
        }
    }
}
