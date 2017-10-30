using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{

    public float curHealth;
    public float maxHealth = 100;

    public SpriteRenderer enemyArt;

    public GameObject coin, music;
    public GameObject gem;

    public int XPMin, XpMax, phaseID;

    public bool inCol, Dead;
    public Image healthBar;

    public Transform target, eyeRoot;

    Animator anim;

    public Sprite P1, P2, P3;

    public Camera2DFollow followCam;

    //shooting
    public float fireCounter;
    public float fireRate = 10.0f;
    public GameObject bloodFire;
    public Transform spawnPoint;
    private AudioSource aS;
    public AudioClip spawnClip;
    public AudioClip roarP1, roarP2, roarP3, death;

    public AudioSource enemyMusic;
    public GameObject enemyMusicO;
    public AudioClip phaseintro, phase1, phase2, phase3;

    // Use this for initialization
    void Start()
    {
        aS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
        aS.PlayOneShot(roarP1, 0.7f);
        StartCoroutine(Start(0.01f));      
    }

    // Update is called once per frame
    void Update()
    {
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        eyeRoot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (inCol && !Dead)
        {
            if (phaseID == 0)
            {
                enemyArt.sprite = P1;
                fireRate = 1f;
                Fire();
                
            }
            else if (phaseID == 1)
            {
                enemyArt.sprite = P2;
                fireRate = 1.5f;
                Fire();
                
            }
            else if (phaseID == 2)
            {
                enemyArt.sprite = P3;
                fireRate = 3f;
                Fire();                
            }
        }
        fireCounter -= Time.deltaTime * fireRate;
    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Arrow")
        {
            if (!Dead)
            {
                curHealth --;
                healthBar.fillAmount = curHealth / maxHealth;
                anim.SetTrigger("Hurt");
                if (curHealth <= 30)
                {
                    phaseID = 1;
                }
                if (curHealth == 30)
                {
                    enemyMusic.clip = phase2;
                    enemyMusic.Play();
                    aS.PlayOneShot(roarP2, 0.7f);
                }
                if (curHealth <= 10)
                {
                    phaseID = 2;
                }
                if (curHealth == 10)
                {
                    enemyMusic.clip = phase3;
                    enemyMusic.Play();
                    aS.PlayOneShot(roarP3, 0.7f);
                }
                if (curHealth <= 0)
                {
                    followCam.deadBoss = true;
                    StartCoroutine(Death(4.0f));                    
                }
            }
        }
    }

    void SpawnEXP()
    {
        float rand = Random.Range(XPMin, XpMax);

        for (int i = 0; i < rand; i++)
        {
            Instantiate(gem, transform.position, transform.rotation);
        }
    }
    public void StartBoss()
    {
        if (!inCol)
        {
            enemyMusic.clip = phase1;
            enemyMusic.Play();
            aS.PlayOneShot(roarP1, 0.7f);
        }
        inCol = true;      
    }

    void Fire()
    {
        if (inCol && fireCounter <= 0.0f)
        {
            aS.PlayOneShot(spawnClip, 0.5f);
            Instantiate(bloodFire, spawnPoint.position, spawnPoint.rotation);
            fireCounter = 1.0f;
        }
    }

    IEnumerator Death(float seconds)
    {
        enemyMusic.clip = phaseintro;
        enemyMusic.PlayOneShot(death, 0.8f);
        Dead = true;
        anim.SetTrigger("Death");
        SpawnEXP();
        yield return new WaitForSeconds(seconds);
        Instantiate(music, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    IEnumerator Start(float seconds)
    {
        enemyMusic.Stop();
        enemyMusic.clip = phaseintro;
        enemyMusic.Play();
        yield return new WaitForSeconds(seconds);
        enemyMusicO.SetActive(true);
    }
}
