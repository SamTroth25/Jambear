using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public PlayerLevelSystem playerLvl;

    //Camera Shake
    public ShakeCamera shake;

    public GlitchEffect glitch;

    // Use this for initialization
    void Start ()
    {
        curHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        HeratUI.sprite = heartSprites[curHealth];
        if (curHealth <= 0)
        {
            ReloadLevel();
        }
    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Coin")
        {
            GetComponent<AudioSource>().pitch = Random.Range(0.95f, 1.05f);
            GetComponent<AudioSource>().PlayOneShot(coinSound, 0.25f);
            scoreMan.AddCoin();
            Destroy(collisionObject.transform.parent.gameObject);
        }
        if (collisionObject.gameObject.tag == "Gem")
        {
            GetComponent<AudioSource>().pitch = Random.Range(0.95f, 1.05f);
            GetComponent<AudioSource>().PlayOneShot(coinSound, 0.25f);
            playerLvl.AddEXP(5.0f);
            Destroy(collisionObject.gameObject);
        }
        if (collisionObject.gameObject.tag == "Enemy")
        {
            print("HurtPlayer");
            curHealth--;
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
            shake.DoShake();
            StartCoroutine(HurtPlayer(0.2f));
        }
        if (collisionObject.gameObject.tag == "EnemyArrow")
        {
            print("HurtPlayer");
            curHealth--;
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
            shake.DoShake();
            StartCoroutine(HurtPlayer(0.2f));
        }
        if (collisionObject.gameObject.tag == "Hurt")
        {
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            GetComponent<AudioSource>().PlayOneShot(hurtSound, 0.25f);
            print("HurtPlayer");
            curHealth--;
            shake.DoShake();
            StartCoroutine(HurtPlayer(0.2f));
        }
        if (collisionObject.gameObject.tag == "Gear")
        {
            print("KillPlayer");
            ReloadLevel();
        }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator HurtPlayer(float WaitTime)
    {
        playerArt.color = Color.red;
        playerArm.color = Color.red;
        glitch.intensity = 1f;
        glitch.colorIntensity = 1f;
        yield return new WaitForSeconds(WaitTime);
        playerArt.color = Color.white;
        playerArm.color = Color.white;
        glitch.intensity = 0f;
        glitch.colorIntensity = 0f;
    }
}
