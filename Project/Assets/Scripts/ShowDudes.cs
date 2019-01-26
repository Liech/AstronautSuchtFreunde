using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDudes : MonoBehaviour
{
    public List<Sprite> Lifes;
    public Life Target;

    public List<GameObject> dudes;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player").GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        var beam = GameObject.Find("Player").GetComponent<Beam>();

        for (int i = 0; i < dudes.Count; i++)
        {
            GameObject newDude = Instantiate(dudes[i % dudes.Count], this.GetComponent<Transform>());
            //Transform t = newAsteroid.GetComponent<Transform>();
            //t.localScale = Vector3.one * Random.Range(minScale, maxScale);


            newDude.GetComponent<RectTransform>().Translate(new Vector3(42f*i, 0,0));
            //newAsteroid.GetComponent<AsteroidAsset>().screenSize = screenSize;
            //newAsteroid.GetComponent<AsteroidAsset>().velocityScaling = velocityScaling;
            newDude.GetComponent<Image>().sprite = dudes[i].GetComponent<SpriteRenderer>().sprite;
            //Debug.Log(dude.name.ToString());
            //Lifes.Add(dude.GetComponent<SpriteRenderer>().sprite);
        }

        if ( Lifes.Count > 0 )
          GetComponent<Image>().sprite = Lifes[0];
    }
}
