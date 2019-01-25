using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public float gravForce = 9.81f;

    private Vector2 downDirection;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        downDirection = -GetComponentInParent<Transform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(downDirection * gravForce);
    }
}
