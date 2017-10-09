using UnityEngine;
using System.Collections;

public class startCamera : MonoBehaviour
{
    public CameraMove cam;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            cam.StartMovement();
            Debug.Log("StartMove");
        }
    }
}
