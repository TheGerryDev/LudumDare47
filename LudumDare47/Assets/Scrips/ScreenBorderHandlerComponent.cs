using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorderHandlerComponent : MonoBehaviour
{
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        var p = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, _cam.pixelHeight, _cam.nearClipPlane));

        if (transform.position.x <= -p.x) transform.position += Vector3.right * p.x * 2f;
        if (transform.position.x >= p.x) transform.position -= Vector3.right * p.x * 2f;
        if (transform.position.y <= -p.y) transform.position += Vector3.up * p.y * 2f;
        if (transform.position.y >= p.y) transform.position -= Vector3.up * p.y * 2f;
    }
}
