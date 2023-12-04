using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    [SerializeField] AudioManager playerAudio;
    private void OnEnable()
    {
        playerAudio.Play("death");
    }
}
