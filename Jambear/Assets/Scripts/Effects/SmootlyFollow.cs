using UnityEngine;
using System.Collections;

public class SmootlyFollow : MonoBehaviour
{
    public Transform Player;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 10);
	}
}
