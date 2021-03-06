using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class fixedOrbitMovement : MonoBehaviour
{
    [Range(0,4000)]
    public float radius = 100f;
    [Range(-6, 6)]
    public float orbitSpeed  = 1f;
    [Range(-1, 1)]
    public float rotationSpeed = 1f;
    public bool rotateObejct = true;
    private Transform orbiterTransform;
    // Start is called before the first frame update
    void Start()
    {
        orbiterTransform = GetComponent<Transform>().GetChild(0).GetComponent<Transform>();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, 3);
    //}

    // Update is called once per frame
    void Update()
    {
        if (orbiterTransform == null)
        {
            return;
        }
        float t = Time.time;
        orbiterTransform.localPosition = new Vector3(Mathf.Cos(t * orbitSpeed), Mathf.Sin(t * orbitSpeed), 0) * radius;
        if(rotateObejct)
            orbiterTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, t * rotationSpeed * 360));
    }

  void StartBossFight()
  {

  }
}
