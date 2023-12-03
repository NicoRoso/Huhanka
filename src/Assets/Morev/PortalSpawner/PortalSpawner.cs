using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    private void Update()
    {
        if(GameObject.FindObjectOfType<Locator>().isOpeningPossible && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SpawnCountdown(3));
        }
    }
    IEnumerator SpawnCountdown(float seconds)
    {
        float timePassed = 0;
        if(!GameObject.FindObjectOfType<Locator>().destination.gameObject.activeSelf)
        {
            while (timePassed < seconds)
            {
                timePassed += Time.deltaTime;
                if (Input.GetKey(KeyCode.F) && GameObject.FindObjectOfType<Locator>().isOpeningPossible)
                {
                    yield return null;
                }
                else
                {
                    yield break;
                }
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
