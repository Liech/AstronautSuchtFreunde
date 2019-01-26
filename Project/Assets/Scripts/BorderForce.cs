using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderForce : MonoBehaviour
{
    public float maxDistance = 2500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionToCenter = -transform.position;
        float distance = directionToCenter.magnitude;
        float overdist = distance - maxDistance;
        if (overdist > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(directionToCenter.normalized * overdist * overdist);
        }
    }
}
