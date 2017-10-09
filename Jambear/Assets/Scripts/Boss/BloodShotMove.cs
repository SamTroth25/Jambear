using UnityEngine;
using System.Collections;

public class BloodShotMove : MonoBehaviour
{

    public float BulletSpeed;
    public Rigidbody2D rb;

    public float lifetime = 0.3f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BulletSpeed);
    }
}
