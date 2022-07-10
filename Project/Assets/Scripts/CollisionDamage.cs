using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CollisionDamage : MonoBehaviour
{
    List<float> damageFactors = new List<float> { 1.0f, 1.3f, 1.8f, 2.5f };
    GameObject player;
    public bool shotByPlayer = false;
    public bool DamageLock = false; // Prohibit Random Deaths without Player interaction

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        float factor = 1.0f;

        CollisionDamage otherCD = collision.gameObject.GetComponent<CollisionDamage>();
        if (otherCD)
            if (otherCD.shotByPlayer) {
                factor = damageFactors[player.GetComponent<Systems>().WeaponLvL - 1];
                DamageLock = false;
            }

        //Debug.Log("WeaponLevel: " + GameObject.Find("Player").GetComponent<Systems>().WeaponLvL.ToString() + ", factor: " + factor.ToString());
        float diff = collision.relativeVelocity.magnitude;
        if (diff > 20f)
            diff = 20f;
        if (DamageLock)
            return;
        GetComponent<Life>().getDamage((int)(diff * factor));
    }
}
