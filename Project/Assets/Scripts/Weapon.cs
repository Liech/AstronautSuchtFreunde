using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireDelta = 0.1f;
    public GameObject projectile;
    public float fuzzyness = 10; //spray angle

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (fireCD > 0)
            fireCD -= Time.deltaTime;
    }


    public void shoot()
    {
        if (fireCD > 0)
            return;
        GameObject bullet = Instantiate(projectile, transform.parent.transform);
        bullet.GetComponent<Fly>().origin = gameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<Fly>().transform.rotation = transform.rotation;
        bullet.GetComponent<Fly>().transform.Rotate(new Vector3(0, 0, Random.Range(-fuzzyness / 2, +fuzzyness / 2)));
        bullet.GetComponent<ProjectileProperties>().fromEnemy = GetComponent<GetDamage>()._isEnemy;
        fireCD = fireDelta;
    }

    private float fireCD = 0;
}
