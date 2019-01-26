using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectFlightpath : MonoBehaviour
{
    [Range(0,1)]
    public float stepsize = 0.1f;
    [Range(10, 200)]
    public int numberOfSteps = 200;
    LineRenderer lr;
    public GravityField gField;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.positionCount = numberOfSteps;
        var pos = transform.position;
        lr.SetPosition(0, transform.position);
        var velo = GetComponentInParent<Rigidbody2D>().velocity;
        for (int i = 1; i < numberOfSteps; i++)
        {
            var gForce = gField.getGravity(pos);
            velo += stepsize*gForce;
            //var mov = (velo + gForce);
            pos += new Vector3(stepsize*velo.x,stepsize*velo.y, 0); 
            lr.SetPosition(i, pos);
        }
    }
}
