using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    AudioManager playerAudio;
    private void Update()
    {
        playerAudio = GetComponent<AudioManager>();
        if(GameObject.FindObjectOfType<Locator>().isOpeningPossible && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SpawnCountdown(2.5f));
        }
    }
    IEnumerator SpawnCountdown(float seconds)
    {
        float timePassed = 0;
        if(!GameObject.FindObjectOfType<Locator>().destination.gameObject.activeSelf)
        {
            playerAudio.Play("openPortalProcess");
            while (timePassed < seconds)
            {
                timePassed += Time.deltaTime;
                if (Input.GetKey(KeyCode.F) && GameObject.FindObjectOfType<Locator>().isOpeningPossible)
                {
                    yield return null;
                }
                else
                {
                    playerAudio.SoftStop("openPortalProcess", 10);
                    yield break;
                }
                playerAudio.Play("portalOpened");
            }
        }
        else
        {
            yield break;
        }
        GameObject.FindObjectOfType<Locator>().destination.gameObject.SetActive(true);
        yield break;
    }
}
