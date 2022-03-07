using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxSanity = 100;
    public int currentSanity = 100;
    public float cashTarget;
    public float cashAmount;
    public Animator animator;

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

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SwitchHead());
    }

    IEnumerator SwitchHead()
    {
        while(true)
        {
            animator.Play("HeadNormal");
            yield return new WaitForSeconds(2f);
            animator.Play("HeadCryXd");
            yield return new WaitForSeconds(2f);
            animator.Play("HeadNormalXd");
            yield return new WaitForSeconds(2f);
            animator.Play("HeadLiuHan");
            yield return new WaitForSeconds(2f);
            animator.Play("HeadDead");
            yield return new WaitForSeconds(2f);
            animator.Play("HeadHappyXd");
            yield return new WaitForSeconds(2f);
        }
    }
}
