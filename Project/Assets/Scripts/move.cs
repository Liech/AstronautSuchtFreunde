﻿using DG.Tweening;
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var particle_emitter = GetComponentsInChildren<ParticleSystem>();
        foreach(var particlesys in particle_emitter)
        {
            particlesys.enableEmission = false;
        }
        
        if (System.Math.Abs(moveHorizontal) + System.Math.Abs(moveVertical) > 0.1)
        {
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f)*GetComponent<Systems>().DriveFactor;
            transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.back, movement));
            if (Input.GetButton("Fire1"))
            {
                rb.AddForce(movement * speed);
                foreach (var particlesys in particle_emitter)
                {
                    particlesys.enableEmission = movement.magnitude>=0.1;
                }
            }
        } else
        {
            var lookdir = GetComponent<Rigidbody2D>().velocity;
            if (lookdir.magnitude>0.5)
                transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.back, GetComponent<Rigidbody2D>().velocity)); 
        }
    }

    public void respawnPlayer()
    {
        transform.position = startingPosition;
        rb.velocity        = startingVelocity;
        Systems.start_time -= 30;

        GameObject.Find("TimeDisplay").transform.DOShakePosition(2, 20);
        GameObject.Find("TimeDisplay").transform.DOShakeScale(1, 0.5f);
    }
}
