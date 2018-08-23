using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 StartPosition;

    private void Start()
    {
        StartPosition = transform.position;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed,tileSizeZ);
        transform.position = StartPosition + Vector3.forward * newPosition;
    }
}
