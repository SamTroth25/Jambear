using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip shieldHit;

    // Use this for initialization
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            col.transform.parent = transform;
            col.GetComponent<ArrowMove>().BulletSpeed = 0;
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.PlayOneShot(shieldHit);
        }
    }
}