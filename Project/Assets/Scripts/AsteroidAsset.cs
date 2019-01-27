using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAsset : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    private TrailRenderer trail;

    public float screenSize = 100;
    public float velocityScaling = 20;

    public Vector2 center;

    private float startVel;

    private float angularAdd = 0;
    private int angularAdds = 0;
    private Vector2 velocityAdd;
    private int velocityAdds = 0;

    private float nextAngularTime = 0f;
    private float nextVelocityTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Random.insideUnitSphere * screenSize + new Vector3(center.x, center.y, 0);
        pos.z = 0;
        transform.position = pos;
        direction = Random.onUnitSphere;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitSphere * velocityScaling;
        startVel = rb.velocity.magnitude;
        rb.angularVelocity = Random.Range(-45f, 45f);
        trail = GetComponent<TrailRenderer>();
        trail.Clear();
    }

    private void OnDrawGizmos()
    {
        //float time = Time.time;
        //Gizmos.color = new Color(1, 0, 0);
        //Gizmos.DrawLine(
        //    transform.position + new Vector3(0, -1, 0),
        //    transform.position + new Vector3(0.5f*(nextAngularTime-time), -1, 0));

        //if (angularAdds > 0)
        //    Gizmos.DrawSphere(transform.position, angularAdd);

        //Gizmos.color = new Color(0, 1, 0);
        //Gizmos.DrawLine(
        //    transform.position + new Vector3(0, -3, 0),
        //    transform.position + new Vector3(0.5f * (nextVelocityTime - time), -3, 0));
        //if (velocityAdds > 0)
        //    Gizmos.DrawSphere(transform.position + new Vector3(0,1,0), 10*velocityAdd.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 pos = rb.position;
        Vector2 vel = rb.velocity;
        //if (Mathf.Abs(pos.x) > screenSize) pos.x *= -0.9f;
        //if (Mathf.Abs(pos.y) > screenSize) pos.y *= -0.9f;

        Vector2 centerDir = center - pos;
        float rubber = centerDir.magnitude / screenSize / 10000;
        vel += rubber * centerDir;

        //rb.position = pos;
        rb.velocity = vel;

        float time = Time.time;

        if (angularAdds > 0)
        {
            rb.angularVelocity += angularAdd;
            angularAdds--;
        }
        if (velocityAdds > 0)
        {
            rb.velocity += velocityAdd;
            velocityAdds--;
        }

        if (time > nextAngularTime)
        {
            angularAdd = Random.Range(-1f, 1f);
            angularAdds = Random.Range(10, 50);
            nextAngularTime += Random.Range(5, 20f);
        }
        if (time > nextVelocityTime)
        {
            velocityAdd = Random.insideUnitCircle * velocityScaling / 50f;
            velocityAdds = Random.Range(10, 50);
            nextVelocityTime += Random.Range(5, 20f);
        }

    }
}
