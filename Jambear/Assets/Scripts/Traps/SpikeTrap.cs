using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject != null)
        {
            if (collisionObject.gameObject.tag == "Player")
            {
                StartCoroutine(spikeActivate(0.25f));
            }
        }
    }
    IEnumerator spikeActivate(float waitTime)
    {
        anim.SetBool("SpikeUp", true);
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("SpikeUp", false);
    }
}
