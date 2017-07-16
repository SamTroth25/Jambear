using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int scoreNum;
    public Text scoretext;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scoretext.text = ("Coins: " + scoreNum);
	}
}
