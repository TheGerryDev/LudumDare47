using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMover : MonoBehaviour
{
    public float speed = 100f;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = Vector2.right * speed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1f;
    }
}
