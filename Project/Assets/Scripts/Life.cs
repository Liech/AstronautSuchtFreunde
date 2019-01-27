using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int currentLife;
    public int MaxLife;
    public bool Invulnerable = false;
    private Color flashColor = Color.blue;


    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //DOTween.Init();
        sr = GetComponent<SpriteRenderer>();
        if (!sr)
            sr = transform.GetComponentInChildren<SpriteRenderer>();
    }

  // Update is called once per frame
    void Update()
    {
        if (currentLife <= 0 && !Invulnerable)
        {
            GameObject g;
            if (MaxLife > 200f)
                g = Instantiate(Resources.Load("multiExplosion", typeof(GameObject))) as GameObject;
            else if (MaxLife > 10f)
                g = Instantiate(Resources.Load("mediumExplosion", typeof(GameObject))) as GameObject;
            else
                g = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            g.transform.localScale = Vector3.one * Mathf.Sqrt(MaxLife);
            g.transform.position = transform.position;
            if (gameObject.name != "Player")
                Destroy(gameObject);
            else
                StartCoroutine(playerDeath());
        }
    }




    public void getDamage(int amount)
    {
        if (!Invulnerable)
            currentLife -= amount;

        if (amount < 0)
            flashColor = Color.green;
        else
            flashColor = Color.blue;
        if (currentLife > MaxLife)
            currentLife = MaxLife;

        StartCoroutine( flash());
    }

    IEnumerator flash()
    {
        Color defaultColor = Color.white; //sr.color;

        //sr.DOBlendableColor(flashColor, 0.1f).SetLoops(1, LoopType.Yoyo);

        if (sr)  sr.color = flashColor;

        yield return new WaitForSeconds(0.1f);

        if (sr)  sr.color = defaultColor;
    }

    IEnumerator playerDeath()
    {
        Invulnerable = true;
        allowPlayerControl(false);

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        yield return new WaitForSeconds(2.5f);


        currentLife = MaxLife;
        GetComponent<move>().respawnPlayer();
        allowPlayerControl(true);
        Invulnerable = false;

    }

    void allowPlayerControl(bool b)
    {
        GetComponent<FireWeapon>().enabled     = b;
        GetComponent<Beam>().enabled           = b;
        GetComponent<move>().enabled           = b;
        GetComponent<SpriteRenderer>().enabled = b;
    }

}
