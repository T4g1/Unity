using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    public void Start()
    {
        startPosition = transform.position;
    }

    public void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);

        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
