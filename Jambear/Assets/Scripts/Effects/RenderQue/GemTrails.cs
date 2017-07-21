using UnityEngine;
using System.Collections;

public class GemTrails : MonoBehaviour
{

    private TrailRenderer myMeshRenderer;

    //
    public string layerName;
    public int sortOrder;

    void Start()
    {
        myMeshRenderer = GetComponent<TrailRenderer>();

        myMeshRenderer.sortingLayerName = layerName;
        myMeshRenderer.sortingOrder = sortOrder;
    }
}