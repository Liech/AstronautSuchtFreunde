using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public List<GameObject> storedDudes = new List<GameObject>();
    GameObject Universe;
    public bool atHome;
    float lastBeamdown;

    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        Universe = GameObject.Find("Universe");
        lastBeamdown = Time.time;
        lr = GameObject.Find("BeamCone").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            var planets = GetComponent<move>().InPlanetInfluence;
            if (planets.Count == 0)
            {
                lr.enabled = false;
                return;
            }

            var hitpos = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x;
            if ((hitpos - transform.position).magnitude > 80f)
            {
                lr.enabled = false;
                return;
            }

            var hitposin = planets[0].transform.position + (transform.position - planets[0].transform.position).normalized * planets[0].transform.lossyScale.x * 0.9f;


            if (!atHome && storedDudes.Count < 5)
            {
                
                if (planets.Count > 0)
                {
                    BossStatus b = planets[0].GetComponent<BossStatus>();
                    if (b)
                        if (!planets[0].GetComponent<BossStatus>().bossDefeated)
                            return;

                    lr.SetPosition(1, transform.InverseTransformPoint(hitposin));
                    lr.enabled = true;
                    var bewohners = planets[0].GetComponentsInChildren<bewohnerMovement>();
                    float minDist = float.MaxValue;
                    GameObject closestBewhoner = null;
                    foreach (var bewohner in bewohners)
                    {
                        float dist = (bewohner.gameObject.transform.position - hitpos).magnitude;
                        if (dist < minDist && dist < 8)
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
                if (atHome && storedDudes.Count > 0)
                {
                    if ((hitpos - transform.position).magnitude > 80f)
                        return;

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
                } else
                {
                    lr.enabled = false;
                }
            }


        } else
        {
            lr.enabled = false;
        }
    }
}
