using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpComponent : MonoBehaviour
{
    public float power;
    private Rigidbody2D _rigidbody2D;
    private float _val;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

//    private void Update()
//    {
//        if (_rigidbody2D.velocity.y < 0f)
//        {
//            EventHandler.OnEntityFall(gameObject);
//        }
//        else if (_val > 0f)
//        {
//            EventHandler.OnEntityJump(gameObject, _val, power);
//            _val = 0f;
//        }
//        
//    }

    void OnJump(InputValue val)
    {
        _val = val.Get<float>();
        EventHandler.OnEntitySetupJump(gameObject, _val, power);
    }
}
