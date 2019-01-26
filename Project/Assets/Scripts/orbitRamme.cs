using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitRamme : MonoBehaviour
{
    private gravityInfluence gI;
    private fixedOrbitMovement fom;

    public float orbitChangeSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        gI = transform.parent.GetComponent<gravityInfluence>();
        fom = GetComponent<fixedOrbitMovement>();

        transform.localScale = Vector3.one / transform.parent.GetComponent<Transform>().localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float targetHeight = gI.playerOrbitHeight;
        if (targetHeight < 120f)
            targetHeight = 120f;
        float currentHeight = fom.radius;

        fom.radius = targetHeight * orbitChangeSpeed + currentHeight * (1f - orbitChangeSpeed);
    }
}
