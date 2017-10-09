using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager textBox;

	public bool DestroyWhenActivated; 

	public bool requireButtonPress;
    private bool waitForPress;

    public GameObject nextText;

	// Use this for initialization
	void Start () {
		textBox = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForPress && Input.GetButtonUp ("Skip Text")) {
			textBox.ReloadScript (theText);
			textBox.currentLine = startLine;
			textBox.endAtLine = endLine;
			textBox.EnableTextBox ();

			if (DestroyWhenActivated) {
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.tag == "Player") {
			if (requireButtonPress) {
				waitForPress = true;
				return;
			}
			textBox.ReloadScript (theText);
			textBox.currentLine = startLine;
			textBox.endAtLine = endLine;
			textBox.EnableTextBox ();

			if (DestroyWhenActivated) {
				Destroy (gameObject);
                nextText.SetActive(true);
			}
		}
	}
}
