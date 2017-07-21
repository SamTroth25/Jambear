using UnityEngine;
using System.Collections;

public class RenderMesh : MonoBehaviour
{

    private Renderer myMeshRenderer;

    //
    public string layerName;
    public int sortOrder;

    void Start()
    {
        myMeshRenderer = GetComponent<Renderer>();

        myMeshRenderer.sortingLayerName = layerName;
        myMeshRenderer.sortingOrder = sortOrder;
    }
}