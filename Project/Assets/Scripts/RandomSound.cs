using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSound : MonoBehaviour {

    public List<AudioSource> Sounds;
    public float Propability = 0.003f;

    bool Play = false;
    float StartTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    GameObject p = GameObject.Find("Player");
    if (!p) return;
    if ((p.transform.position - transform.position).magnitude > 400) return;

	  if (Random.value < Propability)
        {
            Play = true;
            StartTime = Time.time;
            if (Sounds.Count != 0)
            Sounds[(int)(Sounds.Count * Random.value)].GetComponent<AudioSource>().Play();
        }
    }
}
