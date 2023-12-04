using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravitator : MonoBehaviour
{
    float fallSpeed = 0;
    float time = 0;
    float gravityCoefficient = 1;
    Vector3 gravity = Vector3.zero;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime * gravityCoefficient * 9.8f;
        time = Mathf.Clamp(time, -15, 30);
        fallSpeed = time;
        gravity = new Vector3(0, -fallSpeed, 0);
        rb.velocity = gravity;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<TerrainCollider>(out TerrainCollider terrain) && gravityCoefficient > 0)
        {
            time = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<TerrainCollider>(out TerrainCollider terrain) && gravityCoefficient > 0)
        {
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }
    public void ChangeGravity(float newGravity)
    {
        gravityCoefficient = newGravity * Random.Range(0.6f,1.2f);
    }
}
