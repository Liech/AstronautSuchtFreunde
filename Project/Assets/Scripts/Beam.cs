using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public List<GameObject> storedDudes = new List<GameObject>();
    GameObject Universe;
    public bool atHome;
    float lastBeamdown;
    // Start is called before the first frame update
    void Start()
    {
        Universe = GameObject.Find("Universe");
        lastBeamdown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            if (!atHome && storedDudes.Count < 5)
            {
                LineRenderer lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
                var planets = GetComponent<move>().InPlanetInfluence;
                if (planets.Count > 0)
                {
                    var hitpos = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x;
                    var hitposin = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x*0.9f;
                    lr.SetPosition(1, transform.InverseTransformPoint(hitposin));
                    lr.enabled = true;
                    var bewohners = planets[0].GetComponentsInChildren<bewohnerMovement>();
                    float minDist = float.MaxValue;
                    GameObject closestBewhoner = null;
                    foreach (var bewohner in bewohners)
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
                if (storedDudes.Count > 0)
                {
                    LineRenderer lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
                    var planets = GetComponent<move>().InPlanetInfluence;
                    var hitpos = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x;
                    var hitposin = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x*0.9f;
                    var hitposOut = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x*1.1f;
                    lr.SetPosition(1, transform.InverseTransformPoint(hitposin));
                    lr.enabled = true;
                    if (Time.time - lastBeamdown > 2.0f)
                    {
                        var dude = storedDudes[0];
                        storedDudes.Remove(dude);
                        dude.transform.SetParent(planets[0].transform);
                        dude.transform.position = hitposOut;
                        dude.GetComponent<bewohnerMovement>().planetPos = planets[0].transform.position;
                        dude.GetComponent<bewohnerMovement>().jumpStrength = 1.0f;
                        dude.GetComponent<bewohnerMovement>().moveSpeed = 5.0f;
                        dude.SetActive(true);
                        lastBeamdown = Time.time;
                        planets[0].GetComponent<HomeBase>().addDude(dude.GetComponent<BewohnerFarbe>().farbe);
                    }
                }
            }


        } else
        {
            LineRenderer lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
            lr.enabled = false;
        }
    }
}
