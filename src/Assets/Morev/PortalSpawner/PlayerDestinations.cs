using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestinations : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] List<Transform> destinations;
    public Transform currentDestination;
    void FindCurrentDestination()
    {
        float minDistance;
        if (destinations.Count > 0)
        {
            minDistance = (destinations[0].position - _player.position).magnitude;
            currentDestination = destinations[0];
            for (int i = 1; i < destinations.Count; i++)
            {
                if ((destinations[i].position - _player.position).magnitude < minDistance)
                {
                    minDistance = (destinations[i].position - _player.position).magnitude;
                    currentDestination = destinations[i];
                }
            }
        }
    }

    private void Awake()
    {
        FindCurrentDestination();
    }

    private void Update()
    {
        FindCurrentDestination();
    }
}
