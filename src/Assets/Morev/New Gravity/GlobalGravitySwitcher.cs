using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravitySwitcher : MonoBehaviour
{
    List<ObjectGravitator> gravitatedObjects = new List<ObjectGravitator>();
    playerMovementOlegVer player;
    bool playerGravityChangable = false;
    private void Start()
    {
        player = GameObject.FindObjectOfType<playerMovementOlegVer>();
        foreach(ObjectGravitator obj in GameObject.FindObjectsOfType<ObjectGravitator>())
        {
            gravitatedObjects.Add(obj);
        }
        StartCoroutine(GravitySwitcher());
    }
    IEnumerator GravitySwitcher()
    {
        while(true)
        {
            GravityCoefficient(2);
            if(playerGravityChangable)
            {
                player.SetGravityCoefficient(0.5f);
            }
            yield return new WaitForSeconds(5);
            GravityCoefficient(-1);
            if(playerGravityChangable)
            {
                player.SetGravityCoefficient(-0.1f);
            }
            yield return new WaitForSeconds(4);
        }
    }
    public void GravityCoefficient(float newGravity)
    {
        foreach(ObjectGravitator obj in gravitatedObjects)
        {
            obj.ChangeGravity(newGravity);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<playerMovementOlegVer>(out playerMovementOlegVer player))
        {
            playerGravityChangable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<playerMovementOlegVer>(out playerMovementOlegVer player))
        {
            playerGravityChangable = false;
        }
    }
}
