using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateSetupJump : EntityStateBase
{
    //private bool _isJumping;
    
    public override void Setup()
    {
        base.Setup();
        //_isJumping = false;
    }

    public override Vector2 Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
    {
        base.Execute(gameObject, rb, inputValue, actionValue);
        
        //if (_isJumping) return;
        return new Vector2( rb.velocity.x, actionValue * inputValue);
        //_isJumping = true;
    }

    public override void OnCollision(GameObject gameObject, Collision2D other)
    {
        base.OnCollision(gameObject, other);
        
        //_isJumping = false;
        //EventHandler.OnEntityFall(gameObject);
    }
}
