using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 可拾取物 : MonoBehaviour
{
    public float doller;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
