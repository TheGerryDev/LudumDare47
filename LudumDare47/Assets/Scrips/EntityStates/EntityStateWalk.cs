using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EntityStateWalk : EntityStateBase
{
    private bool _isColliding;

    public override void Setup()
    {
        base.Setup();
        _isColliding = false;
    }

    public override void Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
    {
        //if (!_isColliding)
        {
            rb.velocity = new UnityEngine.Vector2(actionValue * inputValue * Time.deltaTime, rb.velocity.y);
        }

        if (rb.velocity == Vector2.zero)
        {
            EventHandler.OnEntityIdle(gameObject);
        }
    }

    public override void OnCollision(GameObject gameObject, Collision2D other)
    {
        base.OnCollision(gameObject, other);
        //_isColliding = true;
    }

    public override void OnCollisionExit(GameObject gameObject, Collision2D other)
    {
        //_isColliding = false;
        EventHandler.OnEntityFall(gameObject);
    }
}
