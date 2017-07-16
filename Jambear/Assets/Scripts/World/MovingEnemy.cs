using UnityEngine;
using System.Collections;

public class MovingEnemy : MonoBehaviour {

	public Transform enemy;
    public SpriteRenderer enemySprite;
    public Rigidbody2D enemyRB;

    //collects player positions and colliders
	public Transform selectedPlayer;

	public bool inCol = false;

	public float Speed;

	public Animator ghostAnim;

	void Start (){

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject != null) {
			if (other.gameObject.tag == "Player") {
				inCol = true;
				//player = other.gameObject.name;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject != null) {
			if (other.gameObject.tag == "Player") {
				inCol = false;
			}
		}
	}

	void FixedUpdate () {

		bool isInRange = false;
        Vector3 direction = (selectedPlayer.transform.position - transform.position).normalized;
        if (inCol){
			float step = Speed * Time.deltaTime;
		// ?? move enemy towards object in collider

			//Debug.Log(selectedPlayer);

			if (selectedPlayer != null){
                enemyRB.MovePosition(transform.position + direction * step);
                isInRange = true;
			}
		}

		enemy.GetComponent<Animator> ().SetBool ("inRange", isInRange);

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
