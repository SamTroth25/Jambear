using UnityEngine;
using System.Collections;

public class SwitchTexture : MonoBehaviour {

	public Sprite[] textures;
	public float changeInterval = 0.35f;
	private SpriteRenderer rend;

	void Start(){
		rend = GetComponent<SpriteRenderer>();
	}

	void Update(){
		if(textures.Length == 0) return;

		int index = Mathf.FloorToInt(Time.time / changeInterval);
		index = index % textures.Length;
		rend.sprite = textures[index];
	}
}
