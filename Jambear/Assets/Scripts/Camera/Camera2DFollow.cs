using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour 
{
	
	public Transform target, target2, boss, player;
	public float smoothSpeed = 1;
    public bool deadBoss;

	void Awake()
	{

	}


	void Start () 
	{

	}

	void Update () 
	{
        if (!deadBoss)
        {
            if (boss.position.y >= player.position.y)
            {
                float yPos = Mathf.Lerp(transform.position.y, target.transform.position.y, smoothSpeed * Time.deltaTime);
                transform.position = new Vector3(0, yPos, -10);
            }
            else if (boss.position.y + 3f <= player.position.y)
            {
                float yPos2 = Mathf.Lerp(transform.position.y, target2.transform.position.y, smoothSpeed * Time.deltaTime);
                transform.position = new Vector3(0, yPos2, -10);
            }
        }
        else if (deadBoss)
        {
            float yPos = Mathf.Lerp(transform.position.y, target.transform.position.y, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(0, yPos, -10);

        }
    }
}