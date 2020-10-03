using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingComponent : MonoBehaviour
{
    public int speed = 100;
    private float _val;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
//        if (Math.Abs(_val) > 0f)
//        {
//            EventHandler.OnEntityMove(gameObject, _val, speed);
//        }
//        else
//        {
//            EventHandler.OnEntityIdle(gameObject);
//        }
    }

    void OnMove(InputValue val)
    {
        _val = val.Get<float>();
        EventHandler.OnEntityMove(gameObject, _val, speed);
    }
}
