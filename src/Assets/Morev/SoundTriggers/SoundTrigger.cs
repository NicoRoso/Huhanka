using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<playerMovementOlegVer>(out playerMovementOlegVer player))
        {

        }
    }
}
