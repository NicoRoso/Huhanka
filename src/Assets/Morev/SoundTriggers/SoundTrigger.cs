using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] List<string> _soundsToPlay;
    [SerializeField] List<string> _soundsToStop;
    [SerializeField] SoundTrigger _otherTrigger;
    [HideInInspector]
    public bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<playerMovementOlegVer>(out playerMovementOlegVer player))
        {
            foreach(string sound in _soundsToPlay)
            {
                player.GetComponent<AudioManager>().Play(sound);
            }
            foreach(string sound in _soundsToStop)
            {
                player.GetComponent<AudioManager>().SoftStop(sound, 100);
            }
            triggered = true;
            gameObject.SetActive(false);
            if(_otherTrigger != null)
            {
                _otherTrigger.gameObject.SetActive(true);
            }
        }
    }
}
