﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    List<GameObject> storedDudes = new List<GameObject>();
    GameObject Universe;
    // Start is called before the first frame update
    void Start()
    {
        Universe = GameObject.Find("Universe");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            float Me = (transform.eulerAngles.z);
            LineRenderer lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
            var planets = GetComponent<move>().InPlanetInfluence;
            if (planets.Count > 0)
            {
                var hitpos = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x;
                lr.SetPosition(1, transform.InverseTransformPoint(hitpos));
                lr.enabled = true;
                var bewohners = planets[0].GetComponentsInChildren<bewohnerMovement>();
                float minDist = float.MaxValue;
                GameObject closestBewhoner = null;
                foreach( var bewohner in bewohners)
                {
                    float dist = (bewohner.gameObject.transform.position - hitpos).magnitude;
                    if (dist < minDist && dist < 5)
                    {
                        minDist = dist;
                        closestBewhoner = bewohner.gameObject;
                    }
                }
                if (closestBewhoner != null)
                {
                    storedDudes.Add(closestBewhoner);
                    closestBewhoner.transform.parent = gameObject.transform;
                    closestBewhoner.SetActive(false);
                }
            }
            

        } else
        {
            LineRenderer lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
            lr.enabled = false;
        }
    }
}
