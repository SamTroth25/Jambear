using UnityEngine;
using System.Collections;

public class lineTrailUpdate : MonoBehaviour
{
    LineRenderer line;
    public Transform endPos;

	// Use this for initialization
	void Start ()
    {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, endPos.transform.position);
	}
}
