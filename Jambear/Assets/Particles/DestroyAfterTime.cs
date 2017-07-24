using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
	public float lifeTime;

	void Update ()
    {
        Destroy(gameObject, lifeTime);
	}
}
