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

            GameObject newAsteroid = Instantiate(asteroids[i % asteroids.Capacity], this.GetComponent<Transform>());
            Transform t = newAsteroid.GetComponent<Transform>();
            t.localScale = Vector3.one * Random.Range(minScale, maxScale);

            newAsteroid.GetComponent<AsteroidAsset>().center = center;
            newAsteroid.GetComponent<AsteroidAsset>().screenSize = screenSize;
            newAsteroid.GetComponent<AsteroidAsset>().velocityScaling = velocityScaling;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
