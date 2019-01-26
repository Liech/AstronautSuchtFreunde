using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiExplosion : MonoBehaviour
{
    public GameObject explosion;
    public int NExplosions = 3;
    public float radius = 0.2f;
    public float delay = 0.1f;

    private float timeTrigger;
    private int spawnedN = 0;

    // Start is called before the first frame update
    void Start()
    {

        timeTrigger = Time.time;

        for (int i = 0; i < NExplosions; i++)
        {
            GameObject g = Instantiate(explosion) as GameObject;
            g.transform.position = transform.position + new Vector3(Random.Range(-radius,radius), Random.Range(-radius, radius),0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedN >= NExplosions)
        {
            Destroy(gameObject);
            return;
        }

        if (Time.time > timeTrigger)
        {
            GameObject g = Instantiate(explosion) as GameObject;
            g.transform.localScale = Vector3.one * 3f * Mathf.Sqrt(spawnedN);
            g.transform.position = transform.position + new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0);
            spawnedN++;
            timeTrigger += delay;
        }
    }
}
