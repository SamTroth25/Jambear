using UnityEngine;
using System.Collections;

public class EyeBat : MonoBehaviour
{
    public Transform enemy;
    public SpriteRenderer enemySprite;
    private Rigidbody2D rb;
    public float moveSpeed;

    //playerPos
    private GameObject player;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + direction * step);

        if (direction.x >= 0)
        {
            //Debug.Log("Moving right " + direction);
            enemySprite.flipX = true;
        }
        else
        {
            //Debug.Log("Moving left " + direction);
            enemySprite.flipX = false;
        }
    }
}
