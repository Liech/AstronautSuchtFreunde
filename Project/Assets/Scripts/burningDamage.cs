using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burningDamage : MonoBehaviour
{
    public int damagePerSecond = 1;
    public Color burnColor = Color.red;

    private float tick = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > tick && other.GetComponent<Life>())
        {
            tick += 1f;
            other.GetComponent<Life>().getDamage(damagePerSecond);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.GetComponent<SpriteRenderer>())
        other.GetComponent<SpriteRenderer>().color = burnColor;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    if (other.GetComponent<SpriteRenderer>())
      other.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
