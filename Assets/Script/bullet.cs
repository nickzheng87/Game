using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    public GameObject Hiteffet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(Hiteffet, transform.position, Quaternion.identity);
        Destroy(effect,1f);
        Destroy(gameObject);
    }

}
