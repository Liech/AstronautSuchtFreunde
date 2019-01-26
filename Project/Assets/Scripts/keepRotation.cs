using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepRotation : MonoBehaviour
{

    public GameObject player = null;

    private void Awake()
    {
        transform.position = player.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (player == null) return;
        transform.position = player.transform.position;
        transform.Translate(new Vector3(0, 0, -70 - player.GetComponent<Rigidbody2D>().velocity.magnitude*0.5f));
    }
    
}
