using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{

    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = GameObject.Find("Player").GetComponent<BorderForce>().maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 getGravity(Vector3 pos)
    {
        var fields = GetComponentsInChildren<gravityInfluence>();
        var grav = Vector2.zero;
        foreach(var field in fields)
        {
            grav += field.getForce(pos);
        }

        // see BorderForce

        Vector3 directionToCenter = -pos;
        float distance = directionToCenter.magnitude;
        float overdist = distance - maxDistance;
        if (overdist > 0)
        {
            grav += (Vector2)(directionToCenter.normalized * overdist * overdist);
        }

        return grav;
    }
}
