using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour
{

    AudioSource audioS;
    public AudioClip enemyHit;

    public GameObject deathAnim;
    public GameObject coin;

    private Rigidbody2D rb;
    private BoxCollider2D colBox;
    WayPoints wp;

    void Start()
    {
        wp = GetComponentInParent<WayPoints>();
        rb = GetComponent<Rigidbody2D>();
        colBox = GetComponent<BoxCollider2D>();
        audioS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(coin, col.transform.position, col.transform.rotation);
            Instantiate(deathAnim, col.transform.position, col.transform.rotation);
            col.gameObject.SetActive(false);
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(enemyHit);
        }      
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            rb.isKinematic = true;
            colBox.enabled = false;
        }
    }
}