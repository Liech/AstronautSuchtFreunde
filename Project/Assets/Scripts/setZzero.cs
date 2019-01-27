using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setZzero : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.z != 0)
        {
            pos.z = 0f;
            transform.position = pos;
        }

    }
}
