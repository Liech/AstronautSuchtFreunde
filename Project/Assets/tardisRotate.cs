using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tardisRotate : MonoBehaviour
{
    public float rotationSpeed = 1f;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, Time.time * rotationSpeed, 0));
    }
}
