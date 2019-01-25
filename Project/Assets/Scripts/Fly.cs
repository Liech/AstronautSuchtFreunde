using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {
    public float _speed=.3f;
    public float _lifetime = 2;
    public GameObject origin;

    // Use this for initialization
    void Start () { 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _lifetime -= Time.deltaTime;
        if (_lifetime < 0)
            Destroy(gameObject);

        transform.Translate(new Vector3(0,1,0) * _speed);
	}
}
