using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateFall : EntityStateBase
{
    public override void OnCollision(GameObject gameObject, Collision2D other)
    {
        base.OnCollision(gameObject, other);
        EventHandler.OnEntityIdle(gameObject);
    }
}
