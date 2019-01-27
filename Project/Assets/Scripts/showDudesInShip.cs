using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDudesInShip : MonoBehaviour
{
    public Beam Target;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = gameObject.name[gameObject.name.Length-1] - 49;
        Target = GameObject.Find("Player").GetComponent<Beam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i >= 5) { Debug.Log("Error DudeInSHip index > 5"); return; }
        if (Target.storedDudes.Count > i)
        {
            gameObject.GetComponent<Image>().sprite = Target.storedDudes[i].GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.clear;
        }

    }
}
