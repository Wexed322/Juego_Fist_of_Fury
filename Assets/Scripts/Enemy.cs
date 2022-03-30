using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocidad;

    [SerializeField] Vector3 inicialPos;
    void Start()
    {
        StartCoroutine(muerte());
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime* velocidad);
    }

    IEnumerator muerte() 
    {
        yield return new WaitForSecondsRealtime(10);
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }


}
