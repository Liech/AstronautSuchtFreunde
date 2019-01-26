using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int currentLife;
    public int MaxLife;
    public Color flashColor = Color.blue;

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
        if (currentLife <= 0)
        {      
          GameObject g = Instantiate(Resources.Load("DeathExplosion", typeof(GameObject))) as GameObject;
          g.transform.position = transform.position;
          Destroy(gameObject);
        }
    }

    public void getDamage(int amount)
    {
        currentLife -= amount;
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

}
