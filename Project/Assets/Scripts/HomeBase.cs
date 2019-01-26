﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    float t;
    int Ngrün = 0;
    int Nlila = 0;
    int Ncat = 0;
    int Nrobo = 0;
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            t = float.MaxValue;
            other.gameObject.GetComponent<Beam>().atHome = false;
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

    public void addDude(BewohnerFarbe.Farbe spec)
    {
        switch (spec)
        {
            case BewohnerFarbe.Farbe.grün:
                if (Ngrün == 0) GameObject.Find("UICanvas").transform.Find("UpgradeUI").gameObject.SetActive(true);
                Ngrün++;
                break;
            case BewohnerFarbe.Farbe.lila:
                if (Nlila == 0) GameObject.Find("UICanvas").transform.Find("UpgradeUI").gameObject.SetActive(true);
                Nlila++;
                break;
            case BewohnerFarbe.Farbe.robo:
                if (Nrobo == 0) GameObject.Find("UICanvas").transform.Find("UpgradeUI").gameObject.SetActive(true);
                Nrobo++;
                break;
            case BewohnerFarbe.Farbe.cat:
                if (Ncat == 0) GameObject.Find("UICanvas").transform.Find("UpgradeUI").gameObject.SetActive(true);
                Ncat++;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
