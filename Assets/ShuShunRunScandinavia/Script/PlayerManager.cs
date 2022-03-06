using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float dollerAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickableObject"))
        {
            dollerAmount += collision.gameObject.GetComponent<¿ÉÊ°È¡Îï>().doller;
        }
    }
}
