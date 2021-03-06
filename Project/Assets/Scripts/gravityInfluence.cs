using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityInfluence : MonoBehaviour
{
    public float gravForce = 9.81f;
    public AnimationCurve gravityCurve = AnimationCurve.Linear(0f,1f,1f,0f);
    private Transform t;
    private float planetRadius;
    private float infleneceRadius;
    public float playerOrbitHeight = 150f;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        planetRadius    = t.lossyScale.x; // as long as the inner collider radius is set to '1'
        infleneceRadius = GetComponent<CircleCollider2D>().radius * t.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 getForce(Vector3 pos)
    {
        if ((GetComponent<Transform>().position - pos).magnitude < GetComponent<CircleCollider2D>().radius * t.lossyScale.x)
        {
            Vector2 downDir = t.position - pos;
            float dist = downDir.magnitude;
            float relPos = (dist - planetRadius) / (infleneceRadius - planetRadius);
            float factor = gravityCurve.Evaluate(relPos);
            return downDir.normalized * gravForce * factor;
        }
        else
            return Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            other.gameObject.GetComponent<move>().InPlanetInfluence.Add(this.gameObject);
        //Debug.Log("entered");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            other.gameObject.GetComponent<move>().InPlanetInfluence.Remove(this.gameObject);
        //Debug.Log("entered");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "GravityInfluenced")
          return;
        Vector2 downDir = t.position - other.GetComponent<Transform>().position;
        float dist = downDir.magnitude;
        Rigidbody2D rbOther = other.GetComponent<Rigidbody2D>();
        if (rbOther)
        {
            float factor = 1.0f;
            if (other.gameObject.name == "Player")
            {
                playerOrbitHeight = dist;
                float relPos = (dist - planetRadius) / (infleneceRadius - planetRadius); // relPos = 1 if at outer rim, relPos = 0 if landed
                factor = gravityCurve.Evaluate(relPos);
            }
            rbOther.AddForce(downDir.normalized  * gravForce * factor);
        }

        
    }
}
