using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public Animator chestAnim;

    public float waitTime;

    public string level;

    private AudioSource audioSo;
    public AudioClip open;

    public ScoreManager scoreMan;

    void Start()
    {
        audioSo = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject != null)
        {
            if (collisionObject.gameObject.tag == "Player")
            {
                chestAnim.SetTrigger("OpenChest");
                StartCoroutine(OpenLevel(waitTime));
            }
        }
    }
    IEnumerator OpenLevel(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
}