using UnityEngine;
using System.Collections;

public class FaceMovingDir : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x >= 0)
        {
            Debug.Log("Moving right " + GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Debug.Log("Moving left " + GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
