using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour {
    public float movespeed = 0.3f;
    public int player = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        Vector3 trans = new Vector3(Input.GetAxis("L_XAxis_"+ player.ToString()), -Input.GetAxis("L_YAxis_"+ player.ToString()), 0)* movespeed;
        float rotAxX = Input.GetAxis("R_XAxis_" + player.ToString());
        float rotAxY = Input.GetAxis("R_YAxis_" + player.ToString());
        
        if (rotAxX != 0 || rotAxY != 0)
        {
            angle = Mathf.Atan2(-rotAxX, -rotAxY) / Mathf.PI * 180.0f;
        }
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
        trans = Quaternion.Euler(new Vector3(0, 0, -angle)) * trans;
        transform.Translate(trans);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), Mathf.Clamp(transform.position.y, -5, 5), 0);
        transform.rotation = rot;
        if (Input.GetAxis("TriggersR_" + player.ToString()) > 0.5 )
            GetComponent<Weapon>().shoot();
	}

    private float angle = 0;
}
