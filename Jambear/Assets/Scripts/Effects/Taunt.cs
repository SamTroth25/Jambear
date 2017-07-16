using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Taunt : MonoBehaviour
{
    public string[] Taunts;
    private bool canTaunt;
    int index;
    int lastIndex;

    public Text text;

    private bool isTyping;

    public float typeSpeed;

    public Animator anim;

    void Start()
    {
        canTaunt = true;
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject != null)
        {
            if (collisionObject.gameObject.tag == "Player")
            {
                if (canTaunt) {
                    GetTaunt();
                }
            }
        }
    }
    void GetTaunt()
    {
        if (lastIndex == index) {
            index = Random.Range(0, Taunts.Length);
            Talk();
        }
        if (lastIndex != index)
        {
            lastIndex = index;
        }
    }
    void Talk()
    {
        canTaunt = false;
        anim.SetBool("textActive", true);
        StartCoroutine(TextScroll(Taunts[index]));       
    }
    private IEnumerator TextScroll(string lineOfText)
    {
        int Letter = 0;
        text.text = "";
        isTyping = true;
        while (isTyping && (Letter < lineOfText.Length - 1))
        {
            text.text += lineOfText[Letter];
            Letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        text.text = lineOfText;
        isTyping = false;
        yield return new WaitForSeconds(10.0f);
        canTaunt = true;
        anim.SetBool("textActive", false);
    }
}
