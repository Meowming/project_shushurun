using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxSanity = 100;
    public int currentSanity = 100;
    public float cashTarget;
    public float cashAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickableObject"))
        {
            cashAmount += collision.gameObject.GetComponent<ø… ∞»°ŒÔ>().doller;
            
        }
        if (collision.gameObject.CompareTag("÷¬À¿’œ∞≠"))
        {
            Destroy(gameObject);
            
        }
    }
}
