using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {

    public float BulletSpeed;
    public Rigidbody2D rb;

    private ScoreManager scoreMan;

    AudioSource audioS;
    public AudioClip arrowHit;
    public AudioClip enemyHit;

    public GameObject deathAnim;

    public float interval;

    public float lifetime = 0.3f;
    Animator arrowAnim;

    public bool reversed;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        arrowAnim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        scoreMan = Camera.main.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BulletSpeed);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            BulletSpeed = 0.0f;
            arrowAnim.SetTrigger("Hit");
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(arrowHit);
            Destroy(gameObject, lifetime);
            Debug.Log("HitWall");
        }
        if (col.gameObject.tag == "Ground")
        {
            BulletSpeed = 0.0f;
            arrowAnim.SetTrigger("Hit");
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(arrowHit);
            Destroy(gameObject, lifetime);
            Debug.Log("HitGround");
        }
        if(col.gameObject.tag == "Enemy")
        {
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(enemyHit);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Target")
        {
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(enemyHit);
            col.GetComponent<Animator>().SetTrigger("Hit");            
        }
    }
}
