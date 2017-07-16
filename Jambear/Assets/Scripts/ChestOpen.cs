using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public Animator chestAnim;

    public float waitTime;

    public string level;

    [Header("UI")]
    public Text highScore;
    public GameObject highScoreIdiecator;
    public Text lastScore;
    public GameObject GameCompleteUI;
    public Animator GameCompleteUIAnim;

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
                saveNewHighScore();
                OpenUI();
            }
        }
    }

    void saveNewHighScore()
    {
        //HighscoresLevelSet.AddNewHighscore(PlayerPrefs.GetString("Player Name"), scoreMan.scoreNum);
        PlayerPrefs.SetInt("LastScore", scoreMan.scoreNum);
        lastScore.text = "" + PlayerPrefs.GetInt("LastScore");
        highScore.text = "" + PlayerPrefs.GetInt("HighScore");

        if (scoreMan.scoreNum > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreMan.scoreNum);
            highScoreIdiecator.SetActive(true);
        }
    }
    void OpenUI()
    {
        GameCompleteUI.SetActive(true);
        GameCompleteUIAnim.SetBool("Activate", true);
    }
}