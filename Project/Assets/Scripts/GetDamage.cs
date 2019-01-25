using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public float _HP = 10.0f;
    public bool _isEnemy = true;

    private void Update()
    {
        if (_HP <= 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fly>().origin != gameObject && _isEnemy != collision.gameObject.GetComponent<ProjectileProperties>().fromEnemy)
        {
            Destroy(collision.gameObject);
            _HP -= collision.gameObject.GetComponent<ProjectileProperties>().damage;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(name != "Enemy")
            _HP -= 5;
        if (collision.gameObject.name == "Enemy" && name != "Enemy")
            Destroy(collision.gameObject);
    }

    private void OnDestroy()
    {
        //GetComponent<Explosion>().Explode();
    }
};
