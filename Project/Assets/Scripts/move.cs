using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    public Vector3 startingVelocity;
    public Vector3 startingPosition;
    public List<GameObject> InPlanetInfluence;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var particle_emitter = GetComponentsInChildren<ParticleSystem>();
        foreach(var particlesys in particle_emitter)
        {
            particlesys.enableEmission = false;
        }

        // rotate with controller

        if (Input.GetButton("Fire1"))
        {
            rb.AddForce(transform.up.normalized * speed);
            foreach (var particlesys in particle_emitter)
            {
                particlesys.enableEmission = true;
            }
        } 
    }

    public void respawnPlayer()
    {
        transform.position = startingPosition;
        rb.velocity        = startingVelocity;
        Systems.start_time -= 30;

        GameObject.Find("TimeDisplay").transform.DOShakePosition(4f, 30f);
        GameObject.Find("TimeDisplay").transform.DOShakeScale(1f, 0.5f);
    }
}
