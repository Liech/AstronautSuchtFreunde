using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BewohnerZuHause : MonoBehaviour
{
    public GameObject grün1;
    public GameObject grün2;
    public GameObject lila1;
    public GameObject lila2;
    public GameObject cat1 ;
    public GameObject cat2 ;
    public GameObject robo1;
    public GameObject robo2;

    private int Ngrün = 0;
    private int Nlila = 0;
    private int Ncat  = 0;
    private int Nrobo = 0;

    private float triggerT = 10f;

    private void Start()
    {
        StartCoroutine(CheckBewohner());
    }

    private void enableHouses()
    {
        grün1.SetActive(Ngrün > 0);
        grün2.SetActive(Ngrün > 2);
        lila1.SetActive(Nlila > 0);
        lila2.SetActive(Nlila > 2);
        cat1 .SetActive(Ncat  > 0);
        cat2 .SetActive(Ncat  > 2);
        robo1.SetActive(Nrobo > 0);
        robo2.SetActive(Nrobo > 2);
    }

    IEnumerator CheckBewohner()
    {
        yield return new WaitForSeconds(triggerT);

        Ngrün = 0;
        Nlila = 0;
        Ncat = 0;
        Nrobo = 0;

        BewohnerFarbe[] f = GetComponentsInChildren<BewohnerFarbe>();
        for (int i = 0; i < f.Length; i++)
        {
            switch (f[i].farbe)
            {
                case BewohnerFarbe.Farbe.grün:
                    Ngrün++;
                    break;
                case BewohnerFarbe.Farbe.lila:
                    Nlila++;
                    break;
                case BewohnerFarbe.Farbe.robo:
                    Nrobo++;
                    break;
                case BewohnerFarbe.Farbe.cat:
                    Ncat++;
                    break;
                default:
                    break;
            }
        }
        enableHouses();

        StartCoroutine( CheckBewohner());
    }

}
