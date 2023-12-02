using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject _blizzard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _blizzard.SetActive(true);
            other.gameObject.GetComponent<TimeDeath>().StartTimer(true);
            RenderSettings.fog = true;
        }
    }
}
