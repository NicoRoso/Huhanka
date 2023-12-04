using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    [SerializeField] string whatToPlay;
    void Start()
    {
        GetComponent<AudioManager>().Play(whatToPlay);
    }

}
