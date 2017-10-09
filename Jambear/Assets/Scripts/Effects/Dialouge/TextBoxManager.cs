using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject chiefTextBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public bool isActive;

	public bool stopPlayerMove;

	public bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

    public GameObject audioS;

	// Use this for initialization
	void Start () {

        audioS.SetActive(false);

        if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
		if(isActive){
			EnableTextBox ();
		}else{
			DisableTextBox ();
		}
	}
	void Update(){
        if (isTyping)
        {
            audioS.SetActive(true);
        }
        else
        {
            audioS.SetActive(false);
        }

        if (!isActive) {
			return ;
		}

		//theText.text = textLines [currentLine];

		if (Input.GetButtonDown ("Skip Text")) {
			if (!isTyping) {
				currentLine += 1;

				if (currentLine > endAtLine) {
					DisableTextBox ();
				} else {
					StartCoroutine (TextScroll(textLines[currentLine]));
				}
			} else if(isTyping && !cancelTyping) {
				cancelTyping = true;
			}
		}
	}

	private IEnumerator TextScroll (string lineOfText){
		int Letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while(isTyping && !cancelTyping && (Letter < lineOfText.Length - 1)){
			theText.text += lineOfText [Letter];
			Letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableTextBox(){
		chiefTextBox.SetActive (true);
		isActive = true;
		if (stopPlayerMove) {
		}

		StartCoroutine (TextScroll(textLines[currentLine]));
	}
	public void DisableTextBox(){
		chiefTextBox.SetActive (false);
		isActive = false;
	}
	public void ReloadScript(TextAsset theText){
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));
		}
	}
}
