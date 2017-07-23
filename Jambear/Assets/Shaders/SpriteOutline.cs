using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour
{
    public Color color = Color.white;

    public  SpriteRenderer spriteRenderer;

    void OnEnable()
    {

    }

    public void EnableOutline()
    {
        UpdateOutline(true);
    }
    public void DisableOutline()
    {
        UpdateOutline(false);
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        spriteRenderer.SetPropertyBlock(mpb);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Aim")
        {
            Debug.Log("in");
            EnableOutline();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Aim")
        {
            DisableOutline();
        }
    }
}