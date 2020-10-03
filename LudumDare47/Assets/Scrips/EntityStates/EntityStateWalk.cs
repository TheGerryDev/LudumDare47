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

    public override Vector2 Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
    {
        return new Vector2(actionValue * inputValue * Time.deltaTime, rb.velocity.y);
    }
}
