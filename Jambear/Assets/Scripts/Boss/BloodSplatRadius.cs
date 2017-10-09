using UnityEngine;
using System.Collections;

public class BloodSplatRadius : MonoBehaviour
{
    //shooting
    public float fireCounter;
    public float fireRate = 10.0f;
    public GameObject bloodFire;
    public Transform[] spawnPoint;
    AudioSource aS;
    public AudioClip spawnClip;

    bossController boss;
    // Use this for initialization
    void Start ()
    {
        aS = GetComponent<AudioSource>();
        boss = GetComponentInParent<bossController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (boss.inCol && !boss.Dead)
        {
            if (boss.phaseID == 0)
            {
                fireRate = Random.Range(0.1f, 0.2f);
                Fire();
            }
            else if (boss.phaseID == 1)
            {
                fireRate = Random.Range(0.2f, 0.5f);
                Fire();
            }
            else if (boss.phaseID == 2)
            {
                fireRate = Random.Range(0.5f, 0.8f);
                Fire();
            }
        }
        fireCounter -= Time.deltaTime * fireRate;
    }
    void Fire()
    {
        if (boss.inCol && fireCounter <= 0.0f)
        {
            aS.PlayOneShot(spawnClip, 0.7f);
            Instantiate(bloodFire, spawnPoint[0].position, spawnPoint[0].rotation);
            Instantiate(bloodFire, spawnPoint[1].position, spawnPoint[1].rotation);
            Instantiate(bloodFire, spawnPoint[2].position, spawnPoint[2].rotation);
            Instantiate(bloodFire, spawnPoint[3].position, spawnPoint[3].rotation);
            fireCounter = 1.0f;
        }
    }
}
