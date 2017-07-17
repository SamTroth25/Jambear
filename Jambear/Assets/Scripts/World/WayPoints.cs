using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour {
	public Transform[] patrolPoints;
	public float moveSpeed;
	private int currentPoint;

	private bool FacingRight;

    public GameObject art;

	// Use this for initialization
	void Start () 
	{
		transform.position = patrolPoints [0].position;
		currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position == patrolPoints[currentPoint].position)
		{
			currentPoint++;
			Flip ();
		}
		if (currentPoint >= patrolPoints.Length)
		{
			currentPoint = 0;
		}

		transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, moveSpeed * Time.deltaTime);
        if(!art.gameObject.active)
        {
            moveSpeed = 0;
            GetComponent<AudioSource>().volume = 0.15f;
        }
	}
	void Flip(){
		FacingRight = !FacingRight;
	
		Vector3 theScale = art.transform.localScale;
		theScale.x *= -1;
        art.transform.localScale = theScale;
	}
}
