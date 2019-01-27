using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setZzero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }
}
