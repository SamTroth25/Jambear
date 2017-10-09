using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour 
{
	
	public Transform target;
	public float smoothSpeed = 1;


	void Awake()
	{

	}


	void Start () 
	{

	}

	void Update () 
	{

        float yPos = Mathf.Lerp(transform.position.y, target.transform.position.y, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(0, yPos, -10);
    }
}