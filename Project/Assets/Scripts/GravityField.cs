using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        return grav;
    }
}
