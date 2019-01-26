using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{

    public List<Sprite> multisprite;
    public float animationTime = 1f;

    private SpriteRenderer sr;
    private int numSprites;
    private int curSprite = 0;
    private float timeTrigger;
    private float timeStep;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = multisprite[curSprite++];
        numSprites = multisprite.Count;
        timeStep = animationTime / numSprites;
        timeTrigger = Time.time + timeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeTrigger)
        {
            if (curSprite == numSprites)
            {
                GameObject.Destroy(gameObject);
                return;
            }

            sr.sprite = multisprite[curSprite++];
        }
    }
}
