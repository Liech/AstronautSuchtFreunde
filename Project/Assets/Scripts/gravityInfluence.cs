using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityInfluence : MonoBehaviour
{
    public float gravForce = 9.81f;

    private Transform t;
    private float planetRadius;
    private float infleneceRadius;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        planetRadius = t.localScale[0];
        infleneceRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Vector2 downDir = t.position - other.GetComponent<Transform>().position;
        float dist = downDir.magnitude;
        Rigidbody2D rbOther = other.GetComponent<Rigidbody2D>();
        if (rbOther)
            rbOther.AddForce(- downDir.normalized * (infleneceRadius - dist) / infleneceRadius * gravForce);
        
    }
}
