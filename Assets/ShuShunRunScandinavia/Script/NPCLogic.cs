using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public bool isReduceSanityOnTouch = true;
    public bool isReduceMoneyOnTouch = true;
    public int sanityDamagePerSecond = 5;
    public int moneyDamagePerSecond = 100;
    public bool canDoDamage = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // say sentence
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDoDamage)
        {
            GameplayManager.instance.player.currentSanity -= sanityDamagePerSecond;
            canDoDamage = false;
            StartCoroutine(DoDamageCooldown());
        }
    }

    IEnumerator DoDamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDoDamage = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
