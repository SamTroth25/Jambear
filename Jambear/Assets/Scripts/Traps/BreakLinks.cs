using UnityEngine;
using System.Collections;

public class BreakLinks : MonoBehaviour
{
    private HingeJoint2D hingeJointConnect;

    void Start()
    {
        hingeJointConnect = GetComponent<HingeJoint2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            if (col.gameObject.tag == "Arrow")
            {
                hingeJointConnect.breakForce = 0;
                Destroy(gameObject, 0.5f);
                Destroy(this);
            }
        }
    }
}
