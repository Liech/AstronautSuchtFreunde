using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burningDamage : MonoBehaviour
{
    public int damagePerSecond = 1;

    private float tick = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > tick)
        {
            tick += 1f;
            other.GetComponent<Life>().currentLife -= damagePerSecond;
        }

    }
}
