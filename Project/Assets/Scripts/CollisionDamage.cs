using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CollisionDamage : MonoBehaviour
{
    List<float> damageFactors = new List<float> { 1.0f, 1.3f, 1.8f, 2.5f };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float factor = damageFactors[GameObject.Find("Player").GetComponent<Systems>().WeaponLvL-1];

        float diff = collision.relativeVelocity.magnitude;
        if (diff > 20f)
            diff = 20f;

        GetComponent<Life>().getDamage((int)(diff * factor));
    }
}
