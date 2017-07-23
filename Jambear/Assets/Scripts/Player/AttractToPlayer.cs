using UnityEngine;
using System.Collections;

public class AttractToPlayer : MonoBehaviour
{
    bool inCol;
    GameObject player;

    public float speed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (inCol)
        {                    
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inCol = true;                 
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inCol = false;
        }
    }
}