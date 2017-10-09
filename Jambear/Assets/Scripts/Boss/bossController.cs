using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{

    public float curHealth;
    public float maxHealth = 100;

    public SpriteRenderer enemyArt;

    public GameObject coin;
    public GameObject gem;

    public int XPMin, XpMax, phaseID;

    public bool inCol, Dead;
    public Image healthBar;

    public Transform target, eyeRoot;

    Animator anim;

    public Sprite P1, P2, P3;

    //shooting
    public float fireCounter;
    public float fireRate = 10.0f;
    public GameObject bloodFire;
    public Transform spawnPoint;
    private AudioSource aS;
    public AudioClip spawnClip;


    // Use this for initialization
    void Start()
    {
        aS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
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
                if (curHealth <= 40)
                {
                    phaseID = 1;
                }
                if (curHealth <= 20)
                {
                    phaseID = 2;
                }
                if (curHealth <= 0)
                {
                    StartCoroutine(Death(3.5f));
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
        inCol = true;
    }

    void Fire()
    {
        if (inCol && fireCounter <= 0.0f)
        {
            aS.PlayOneShot(spawnClip, 0.7f);
            Instantiate(bloodFire, spawnPoint.position, spawnPoint.rotation);
            fireCounter = 1.0f;
        }
    }

    IEnumerator Death(float seconds)
    {
        Dead = true;
        anim.SetTrigger("Death");
        SpawnEXP();
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
