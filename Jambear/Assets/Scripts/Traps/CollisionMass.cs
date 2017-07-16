using UnityEngine;
using System.Collections;

public class CollisionMass : MonoBehaviour
{

    public Rigidbody2D rb;
    public float massChange;

    public GameObject ropes;

    public string collisionType;

    public bool destroyChildren; 

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == collisionType)
        {
            rb.mass = massChange;
            if (destroyChildren) {
                Destroy(ropes);
            }
        }
    }
}
