using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PixelEnemy : MonoBehaviour {

	public float moveForce = 365f;
	public float maxSpeed = 1f;
	public int _direction = -1;
	private SpriteRenderer _spriteRenderer;

    public GameObject[] spawnpoints;

	//private Animator anim;
	private Rigidbody2D _rb2d;
    private void OnEnable()
    {
        _rb2d.velocity = Vector3.zero;
        FlipRight();
        spawnpoints = GameObject.FindGameObjectsWithTag("Portal");
    }

    void Awake () 
	{
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();
 
    }

	void Update ()
    { 
        //draws an invisible line on the left edge of the sprite to check if bumped into a wall
        bool hitLeft = Physics2D.Linecast(transform.position + new Vector3(-0.18f, 0.05f, 0), transform.position + new Vector3(-0.18f, -0.05f, 0), 1 << LayerMask.NameToLayer("EnemyCol"));
        if (hitLeft)
        {
            FlipRight();
            Debug.Log("Hit Left Wall");
        }
        //draws an invisible line on the right edge of the sprite to check if bumped into a wall
        bool hitRight = Physics2D.Linecast(transform.position + new Vector3(0.18f, 0.05f, 0), transform.position + new Vector3(0.18f, -0.05f, 0), 1 << LayerMask.NameToLayer("EnemyCol"));
        if (hitRight) {
            FlipLeft();
            Debug.Log("Hit Right Wall");
        }
    }

	void FixedUpdate()
	{
		if (_direction * _rb2d.velocity.x < maxSpeed)
            _rb2d.AddForce(Vector2.right * _direction * moveForce);

		if (Mathf.Abs (_rb2d.velocity.x) > maxSpeed)
            _rb2d.velocity = new Vector2(Mathf.Sign (_rb2d.velocity.x) * maxSpeed, _rb2d.velocity.y);
	}


	void FlipLeft()
	{
        _direction = -1;
		_spriteRenderer.flipX = false;

	}

	void FlipRight()
	{
		_direction = 1;
        _spriteRenderer.flipX = true;

	}
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Portal")
        {
            transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position;
        }
    }	
}