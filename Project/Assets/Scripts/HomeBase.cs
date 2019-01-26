using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            t = Time.time + 10f;
            other.gameObject.GetComponent<Beam>().atHome = true;
            var UI = GameObject.Find("UICanvas");
            //UI.GetComponentInChildren<>().text = "Home Sweet Home";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            t = float.MaxValue;
            other.gameObject.GetComponent<Beam>().atHome = false;
            var UI = GameObject.Find("UICanvas");
            //UI.GetComponentInChildren<TextMesh>().text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name != "Player")
            return;
        if (Time.time > t)
        {
            other.gameObject.GetComponent<Life>().getDamage(-10);
            t += 2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
