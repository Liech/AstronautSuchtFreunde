using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
public class LifeColorIndicator : MonoBehaviour
{
    Life l;
    SpriteRenderer renderer = null;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Life>();
        if (GetComponent<SpriteRenderer>())
            renderer = GetComponent<SpriteRenderer>();
        else if (transform.childCount > 0 && transform.GetChild(0).GetComponent<SpriteRenderer>())
            renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!renderer)
            return;
        float perc = ((float)l.currentLife / (float)l.MaxLife);
        renderer.color = new Color(1, perc, perc);
    }
}
