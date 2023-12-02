using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFallTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _tree;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _tree.GetComponent<Animator>().SetTrigger("Fall");
        }
    }
}
