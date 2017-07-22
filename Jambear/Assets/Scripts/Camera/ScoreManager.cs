using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    //level score
    public int scoreNum;
    public Text scoretext;

	// Use this for initialization
	void Start ()
    {
        scoreNum = PlayerPrefs.GetInt("CoinNum");
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoretext.text = (" " + scoreNum);
	}
    public void AddCoin()
    {
        scoreNum += 5;
        PlayerPrefs.SetInt("CoinNum", scoreNum);
    }
}
