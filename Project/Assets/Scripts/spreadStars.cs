using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreadStars : MonoBehaviour
{
    [Range(1, 1000)]
    public int numStars = 10;

    [Range(0, 2)]
    public float minScale = 1;
    [Range(0, 5)]
    public float maxScale = 1;

    public List<GameObject> stars;

    private Vector3 pos;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        pos   = GetComponent<Transform>().position;
        scale = GetComponent<Transform>().localScale;

        for (int i = 0; i < numStars; i++)
        {
            GameObject newStar = Instantiate(stars[i % stars.Capacity], this.GetComponent<Transform>() );
            Transform t = newStar.GetComponent<Transform>();
            t.localScale = Vector3.one * Random.Range(minScale, maxScale) * 0.001f;
            t.localPosition   = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            t.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }

    }                                                                             

   //private void OnDrawGizmos()
   //{
   //    Gizmos.DrawCube(pos, 2*scale);
   //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
