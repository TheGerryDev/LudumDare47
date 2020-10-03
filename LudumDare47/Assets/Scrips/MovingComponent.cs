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

    public bool _isCollidingWithLeftWall;
    public bool _isCollidingWithRightWall;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        //EventHandler.OnEntityMove(gameObject, _val, speed);
        Vector2 vec;
        vec = new Vector2(speed * _val * Time.deltaTime, _rigidbody2D.velocity.y);

        if ((_isCollidingWithLeftWall && _val <= 0f) || (_isCollidingWithRightWall && _val >= 0f))
        {
            vec = new Vector2(0f, _rigidbody2D.velocity.y);
        }
        _rigidbody2D.velocity = vec;
//        if (Math.Abs(_val) > 0.5f)
//        {
//            EventHandler.OnEntityMove(gameObject, _val, speed);
//        }
//        else
//        {
//            _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
//            //EventHandler.OnEntityIdle(gameObject);
//        }
    }

    void OnMove(InputValue val)
    {
        _val = val.Get<float>();
        //EventHandler.OnEntityMove(gameObject, _val, speed);
    }

    private void OnTriggerEnter2D(Collider2D other1)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Contains("LeftWallCollider") && child.gameObject.GetComponent<TriggerState>().isColliding)
            {
                _isCollidingWithLeftWall = true;
            }
            
            if (child.gameObject.tag.Contains("RightWallCollider") && child.gameObject.GetComponent<TriggerState>().isColliding)
            {
                _isCollidingWithRightWall = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other1)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Contains("LeftWallCollider") && !child.gameObject.GetComponent<TriggerState>().isColliding)
            {
                _isCollidingWithLeftWall = false;
            }
            
            if (child.gameObject.tag.Contains("RightWallCollider") && !child.gameObject.GetComponent<TriggerState>().isColliding)
            {
                _isCollidingWithRightWall = false;
            }
        }
    }
}
