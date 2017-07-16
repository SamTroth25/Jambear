using UnityEngine;
using System.Collections;

public class AudioChange : MonoBehaviour
{
    public Transform player;
    public AudioSource[] levelAudioSource;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float lerp = Mathf.PingPong(player.position.y, player.position.y);
        for (var i = 0; i < levelAudioSource.Length; i++)
        {
            levelAudioSource[i].pitch = lerp;
        }
    }
}
