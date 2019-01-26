using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomLaserSprite : MonoBehaviour
{
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count - 1)];
        Vector3 dir = transform.parent.GetComponent<Rigidbody2D>().velocity;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }
}
