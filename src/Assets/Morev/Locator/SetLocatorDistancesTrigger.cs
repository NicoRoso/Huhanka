using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocatorDistancesTrigger : MonoBehaviour
{
    [SerializeField] int dist12;
    [SerializeField] int dist23;
    [SerializeField] int dist34;
    [SerializeField] int dist45;
    [SerializeField] bool needCharge;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<playerMovementOlegVer>(out playerMovementOlegVer player))
        {
            GameObject.FindObjectOfType<Locator>().ChangeDistances(dist12,dist23,dist34,dist45);
            GameObject.FindObjectOfType<Locator>().spawnerNeedCharge = needCharge;
            gameObject.SetActive(false);
        }
    }
}
