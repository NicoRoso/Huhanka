using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravitySwitcher : MonoBehaviour
{
    List<ObjectGravitator> gravitatedObjects = new List<ObjectGravitator>();
    playerMovementOlegVer player;
    bool playerGravityChangable = false;
    float playerGravity = 1;
    private void Start()
    {
        player = GameObject.FindObjectOfType<playerMovementOlegVer>();
        foreach(ObjectGravitator obj in GameObject.FindObjectsOfType<ObjectGravitator>())
        {
            gravitatedObjects.Add(obj);
        }
        StartCoroutine(GravitySwitcher());
    }
    private void Update()
    {
        if(playerGravityChangable)
        {
            player.SetGravityCoefficient(playerGravity);
        }
    }
    IEnumerator GravitySwitcher()
    {
        while(true)
        {
            GravityCoefficient(2);
            playerGravity = 0.5f;
            yield return new WaitForSeconds(5);
            GravityCoefficient(-1);
            playerGravity = -0.1f;
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
            player.SetGravityCoefficient(1);
        }
    }
}
