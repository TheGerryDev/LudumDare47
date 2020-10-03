using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EntityStateWalk : EntityStateBase
{
//    private bool _isCollidingWithWall;
//
//    public override void Setup()
//    {
//        base.Setup();
//        _isCollidingWithWall = false;
//    }

//    public override Vector2 Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
//    {
//        return base.Execute(gameObject, rb, inputValue, actionValue);
////        if (_isCollidingWithWall)
////        {
////            //EventHandler.OnEntityFall(gameObject);
////            return new Vector2(rb.velocity.x - actionValue * inputValue * Time.deltaTime, rb.velocity.y);
////        }
////        else
////        {
////            return new Vector2(actionValue * inputValue * Time.deltaTime, rb.velocity.y);
////        }
//    }

//    public override void OnCollision(GameObject gameObject, Collision2D other)
//    {
//        base.OnCollision(gameObject, other);
//        var rb = gameObject.GetComponent<Rigidbody2D>();
//        if (gameObject.GetComponent<EntityStateHandlerComponent>().cannotJump)
//        {
//            _isCollidingWithWall = true;
//        }
//    }

//    public override void OnCollisionExit(GameObject gameObject, Collision2D other)
//    {
//        base.OnCollisionExit(gameObject, other);
////        _isCollidingWithWall = false;
//    }

//    public override void OnCollision(GameObject gameObject, Collision2D other)
//    {
//        base.OnCollision(gameObject, other);
//
//        foreach (Transform child in gameObject.transform)
//        {
//            if (child.gameObject.tag.Contains("WallCollider") && child.gameObject.GetComponent<CollidingState>().isColliding)
//            {
//                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
//            }
//        }
//    }
}
