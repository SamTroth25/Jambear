using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int curHealth;
    public int maxHealth = 3;

    public SpriteRenderer enemyArt;

    public GameObject coin;
    public GameObject gem;

    public int XPMin, XpMax;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            Death();
        }
    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Arrow")
        {
            curHealth--;
            StartCoroutine(HurtPlayer(0.1f));
        }
    }
    void Death()
    {
        Instantiate(coin, transform.position, transform.rotation);
        SpawnEXP();
        Destroy(gameObject);
    }
    void SpawnEXP()
    {
        float rand = Random.Range(XPMin, XpMax);

        for (int i = 0; i < rand; i++)
        {
            Instantiate(gem, transform.position, transform.rotation);
        }
    }
    IEnumerator HurtPlayer(float WaitTime)
    {
        enemyArt.color = Color.red;
        enemyArt.color = Color.red;
        yield return new WaitForSeconds(WaitTime);
        enemyArt.color = Color.white;
        enemyArt.color = Color.white;
    }
}
