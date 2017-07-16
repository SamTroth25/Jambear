using UnityEngine;
using System.Collections;

public class Cursour : MonoBehaviour {

	public Vector2 mouse;

	[Header("MouseCursors")]
	public Texture2D yourCursor;
	public Texture2D clickCursor;

	public int sizeX = 16;
	public int sizeY = 16;

	private bool mouseDown;

	public AudioSource audioSource;
	public AudioClip click;

	// Use this for initialization
	void Start ()
    {
		Cursor.visible = false;
	}

	void Update()
    {
		mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		if(Input.GetMouseButtonDown(0))
        {
			mouseDown = true;
		}else if(Input.GetMouseButtonUp(0))
        {
			mouseDown = false;
			//audioSource.PlayOneShot (click, 0.7f);
		}
	}

	void OnGUI ()
    {
		if(mouseDown)
        {
			GUI.DrawTexture (new Rect (mouse.x - (sizeX / 2), mouse.y - (sizeY / 2), sizeX, sizeY), clickCursor);
		}
        else
        {
			GUI.DrawTexture (new Rect (mouse.x - (sizeX / 2), mouse.y - (sizeY / 2), sizeX, sizeY), yourCursor);
		}
	}
}
