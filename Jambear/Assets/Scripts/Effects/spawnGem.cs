using UnityEngine;
using System.Collections;

public class spawnGem : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        Vector3 explosionPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(0,2), Random.Range(5, 10)), ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
