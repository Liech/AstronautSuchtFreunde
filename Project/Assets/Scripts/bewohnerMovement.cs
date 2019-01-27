using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewohnerMovement : MonoBehaviour
{
    public float moveSpeed  = 5;
    public float jumpStrength = 500;
    public Vector3 planetPos;


    private float nextTurnTime = 5f;
    private float nextJumpTime = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    if (transform.parent == null) return;
        planetPos = transform.parent.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = planetPos - transform.position; // this should be 'down'
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void FixedUpdate()
    {
        float time = Time.time;

        if (time > nextJumpTime)
        {
            //if (Random.Range(0f, 1f) > 0.99f)
            //    jump(10000f); // infinitity jump
            //    // maybe play 'wilhelms scream' here
            jump(Random.Range(0f, jumpStrength));
            nextJumpTime += Random.Range(3f, 6f);
        }

        if (time > nextTurnTime)
        {
            turnAround();
            nextTurnTime += Random.Range(5f, 10f);
        }

        Vector3 s = transform.localScale;
        moveClockwise(Random.Range(0f, moveSpeed * s.x));
    }

    private void moveClockwise(float speed)
    {
        transform.position += transform.TransformDirection(Vector3.right) * speed;
    }

    private void jump(float strength)
    {
        rb.AddForce(transform.TransformDirection(Vector3.up) * strength);
    }

    private void turnAround()
    {
        Vector3 s = transform.localScale;
        s.x = -s.x;
        transform.localScale = s;
    }
}
