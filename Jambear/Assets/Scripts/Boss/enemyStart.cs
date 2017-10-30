using UnityEngine;
using System.Collections;

public class enemyStart : MonoBehaviour
{
    public Animator anim;
    public bossController bossCon;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && bossCon.Dead == false)
        {
            bossCon.StartBoss();
            anim.SetTrigger("TriggerBoss");
            Debug.Log("StartMove");
        }
    }
}
