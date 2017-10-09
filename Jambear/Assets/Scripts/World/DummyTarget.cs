using UnityEngine;
using System.Collections;

public class DummyTarget : MonoBehaviour
{
    public float lifetime;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            col.transform.parent = transform;
            col.GetComponent<ArrowMove>().BulletSpeed = 0;
            Destroy(col.gameObject, lifetime);
        }
        if (col.gameObject.tag == "EnemyArrow")
        {
            Destroy(col.gameObject, lifetime);
        }
    }
}
