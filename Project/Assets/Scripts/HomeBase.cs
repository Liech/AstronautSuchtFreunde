using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    float t;
    int Ngrün = 0;
    int Nlila = 0;
    int Ncat = 0;
    int Nrobo = 0;
    public GameObject upgradeUI;
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
        int numberOfSpecs = (Ngrün > 0 ? 1 : 0) + (Nlila > 0 ? 1 : 0) + (Nrobo > 0 ? 1 : 0) + (Ncat > 0 ? 1 : 0);
        switch (spec)
        {
            case BewohnerFarbe.Farbe.grün:
                if (Ngrün == 0) { if (numberOfSpecs < 3) upgradeUI.GetComponent<ShowGUI>().showME(); else Debug.Log("You won after " + (Time.time - GameObject.Find("/Player").GetComponent<Systems>().totalTime).ToString() + "s"); }
                Ngrün++;
                break;
            case BewohnerFarbe.Farbe.lila:
                if (Nlila == 0) { if (numberOfSpecs < 3) upgradeUI.GetComponent<ShowGUI>().showME(); else Debug.Log("You won after " + (Time.time - GameObject.Find("/Player").GetComponent<Systems>().totalTime).ToString() + "s"); }
                Nlila++;
                break;
            case BewohnerFarbe.Farbe.robo:
                if (Nrobo == 0) { if (numberOfSpecs < 3) upgradeUI.GetComponent<ShowGUI>().showME(); else Debug.Log("You won after " + (Time.time - GameObject.Find("/Player").GetComponent<Systems>().totalTime).ToString() + "s"); }
                Nrobo++;
                break;
            case BewohnerFarbe.Farbe.cat:
                if (Ncat == 0) { if (numberOfSpecs < 3) upgradeUI.GetComponent<ShowGUI>().showME(); else Debug.Log("You won after " + (Time.time - GameObject.Find("/Player").GetComponent<Systems>().totalTime).ToString() + "s"); }
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
