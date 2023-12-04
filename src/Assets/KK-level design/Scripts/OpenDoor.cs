using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool isOpenable = false;
    private void Start()
    {
        StartCoroutine(StartTimer(38));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isOpenable)
        {
            GetComponent<Animator>().SetTrigger("Open");
            GetComponent<AudioManager>().Play("open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isOpenable)
        {
            GetComponent<Animator>().SetTrigger("Close");
            GetComponent<AudioManager>().Play("close");
        }
    }
    IEnumerator StartTimer(int time)
    {
        yield return new WaitForSeconds(time);
        isOpenable = true;
    }
}
