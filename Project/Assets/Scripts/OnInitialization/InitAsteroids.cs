using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAsteroids : MonoBehaviour
{
    [Range(1, 1000)]
    public int numAsteroids = 10;

    [Range(1, 2)]
    public float minScale = 1.5f;
    [Range(2, 5)]
    public float maxScale = 3;

    public float screenSize = 100;
    public float velocityScaling = 20;

    public Vector2 center;

    public List<GameObject> asteroids;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < numAsteroids; i++)
        {
            //AsteroidAsset newAsteroid = new AsteroidAsset();
            //asteroids.Add(newAsteroid);
            //Instantiate(newAsteroid);
            //asteroids.Add(Instantiate(prefab));

            GameObject newAsteroid = asteroids[i % asteroids.Capacity];
            
            Transform t = newAsteroid.GetComponent<Transform>();
            t.localScale = Vector3.one * Random.Range(minScale, maxScale);
            //Instantiate(newStar, this.GetComponent<Transform>());

            GameObject obj = Instantiate(newAsteroid);

            obj.GetComponent<AsteroidAsset>().center = center;
            obj.GetComponent<AsteroidAsset>().screenSize = screenSize;
            obj.GetComponent<AsteroidAsset>().velocityScaling = velocityScaling;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
