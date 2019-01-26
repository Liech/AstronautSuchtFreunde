using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDudesInShip : MonoBehaviour
{
    public Life Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player").GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        var beam = Target.GetComponent<Beam>();
        for ( int i = 0; i < beam.storedDudes.Count; ++i)
        {
            if (i >= 5) continue;
            name = "DudeInShip_" + (i + 1).ToString();
            gameObject.transform.Find(name).GetComponent<Image>().sprite = beam.storedDudes[i].GetComponent<SpriteRenderer>().sprite;
            gameObject.transform.Find(name).GetComponent<Image>().color = Color.white;
        }

        for (int i = beam.storedDudes.Count; i < 5;  ++i)
        {
            name = "DudeInShip_" + (i + 1).ToString();
            gameObject.transform.Find(name).GetComponent<Image>().color = Color.clear;
        }

    }
}
