using UnityEngine;
using System.Collections;

public class ArrowMirror : MonoBehaviour
{
    public GameObject hitEffect;
    AudioSource audioS;
    public AudioClip mirrorSound;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            if (col.GetComponent<ArrowMove>().reversed)
            {
                col.transform.parent = transform;
                col.GetComponent<ArrowMove>().BulletSpeed = 12;
                col.GetComponentInChildren<SpriteRenderer>().flipX = false;
                col.GetComponent<ArrowMove>().reversed = false;
                Effect(col);
            }
            else
            {
                col.transform.parent = transform;
                col.GetComponent<ArrowMove>().BulletSpeed = -12;
                col.GetComponentInChildren<SpriteRenderer>().flipX = true;
                col.GetComponent<ArrowMove>().reversed = true;
                Effect(col);
            }
        }
    }
    void Effect(Collider2D col)
    {
        Instantiate(hitEffect, col.transform.position, col.transform.rotation);
        audioS.PlayOneShot(mirrorSound, 0.7f);
    }
}
