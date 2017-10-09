using UnityEngine;
using System.Collections;

public class SmoothZoomCamera : MonoBehaviour
{
    public Camera cam;
    float moveSpeed = 1;
    float speed;
    public float minSize, maxSize;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = moveSpeed * Time.deltaTime;
        cam.orthographicSize = Mathf.Lerp(minSize, maxSize, speed);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //cam.orthographicSize = Mathf.Lerp(minSize, maxSize, speed);
            Debug.Log("StartMove");
        }
    }
}
