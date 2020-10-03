using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateJump : EntityStateBase
{
    private bool _isJumping;
    
    public override void Setup()
    {
        base.Setup();
        _isJumping = false;
    }

    public override void Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
    {
        base.Execute(gameObject, rb, inputValue, actionValue);
        
        if (_isJumping) return;
        rb.velocity = new Vector2( rb.velocity.x, actionValue * inputValue * Time.deltaTime);
        _isJumping = true;
    }

    public override void OnCollision(GameObject gameObject, Collision2D other)
    {
        base.OnCollision(gameObject, other);
        
        //_isJumping = false;
        //EventHandler.OnEntityFall(gameObject);
    }
}
