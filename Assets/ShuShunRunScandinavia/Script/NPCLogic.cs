using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public AudioSource audioSource;
    public bool isReduceSanityOnTouch = true;
    public bool isReduceMoneyOnTouch = true;
    public int sanityDamagePerSecond = 5;
    public int moneyDamagePerSecond = 100;
    public bool canDoDamage = true;
    public bool isHavingSpeech = false;
    public float moveSpeed = 5f;
    public bool isFollowingPlayer = false;
    public float playerDistanceEpsilon = 0.5f; // Mininum distance to chase the player
    public AudioClip[] speechClips;
    public GameObject[] speechDisplays; // Sentence the NPC says when the player touches him
    public Transform speechPos;
    public float speechDuration = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (speechDisplays.Length > 0 && !isHavingSpeech)
            {
                StartCoroutine(ShowSpeech());

            }
            if (speechClips.Length > 0 && isHavingSpeech)
            {
                audioSource.clip = speechClips[0];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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

    IEnumerator ShowSpeech()
    {
        isHavingSpeech = true;
        int seq = Random.Range(0, speechDisplays.Length);
        while (true)
        {
            if (seq >= speechDisplays.Length)
            {
                seq = 0;
            }
            GameObject speech = Instantiate(speechDisplays[seq], speechPos.position, speechPos.rotation, speechPos);
            seq++;
            yield return new WaitForSeconds(speechDuration);       
            Destroy(speech);
        }
    }

    IEnumerator DoDamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDoDamage = true;
    }

    IEnumerator DetectPlayerDistance()
    {
        yield return new WaitForSeconds(1f);
        canDoDamage = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 relativeVec = transform.position - GameplayManager.instance.player.transform.position;
            if (Mathf.Abs(relativeVec.x) > playerDistanceEpsilon)
            {
                if (relativeVec.x > 0) //player is on the left side
                {
                    rigidbody.MovePosition((Vector2)transform.position - Vector2.right * moveSpeed * Time.deltaTime);
                }
                else
                {
                    rigidbody.MovePosition((Vector2)transform.position + Vector2.right * moveSpeed * Time.deltaTime);
                }
            }            
        }
    }
}
