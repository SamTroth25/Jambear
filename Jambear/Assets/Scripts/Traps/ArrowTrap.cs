using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour
{

    public GameObject arrowFire;
    private bool canShoot;
    public Animator anim;

    public Transform firePoint;

    public AudioClip fireSound;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject != null)
        {
            if (collisionObject.gameObject.tag == "Player")
            {
                GetComponent<AudioSource>().pitch = Random.Range(0.95f, 1.05f);
                FireArrow();
                anim.SetBool("Shoot", true);
            }
        }
    }
    void FireArrow()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(arrowFire, firePoint.position, firePoint.rotation);
        }
    }
}
