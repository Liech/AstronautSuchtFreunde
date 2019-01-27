using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtVelocityDir : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rb.velocity);
    }
}
