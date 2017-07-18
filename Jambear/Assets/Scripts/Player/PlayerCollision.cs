using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    //Audio clips for the character
    public AudioClip coinSound;
    public AudioClip goalSound;
    public AudioClip hurtSound;

    public SpriteRenderer playerArt;
    public SpriteRenderer playerArm;

    //Stats for characters health
    public int curHealth;
    public int maxHealth = 3;
    public Sprite[] heartSprites;
    public Image HeratUI;

    public ScoreManager scoreMan;

    //Camera Shake
    public ShakeCamera shake;

    // Use this for initialization
    void Start ()
    {
        curHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        HeratUI.sprite = heartSprites[curHealth];
        if (curHealth == 0)
        {
            //reload level.
        }
    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
            if (collisionObject.gameObject.tag == "Coin")
            {
                GetComponent<AudioSource>().pitch = Random.Range(0.95f, 1.05f);
                GetComponent<AudioSource>().PlayOneShot(coinSound, 0.25f);
                scoreMan.scoreNum += 5;
                Destroy(collisionObject.transform.parent.gameObject);
            }

            if (collisionObject.gameObject.tag == "Enemy")
            {
                print("HurtPlayer");
                curHealth--;
                GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
                GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
                shake.DoShake();
                StartCoroutine(HurtPlayer(0.1f));
            }
            if (collisionObject.gameObject.tag == "Hurt")
            {
                print("HurtPlayer");
                curHealth--;
                StartCoroutine(HurtPlayer(0.1f));
            }
        if (collisionObject.gameObject.tag == "Gear")
        {
            print("KillPlayer");
            //reloadLevel
            //curHealth -= KillDamage;
        }      
    }
    IEnumerator HurtPlayer(float WaitTime)
    {
        playerArt.color = Color.red;
        playerArm.color = Color.red;
        yield return new WaitForSeconds(WaitTime);
        playerArt.color = Color.white;
        playerArm.color = Color.white;
    }
}
