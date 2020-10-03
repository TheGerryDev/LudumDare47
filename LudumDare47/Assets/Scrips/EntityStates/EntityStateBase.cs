using UnityEngine;

public class EntityStateBase
{
    public virtual void Setup()
    {
        
    }
    
    public virtual void Execute(GameObject gameObject, Rigidbody2D rb, float inputValue, float actionValue)
    {
    }

    public virtual void OnCollision(GameObject gameObject, Collision2D other)
    {
    }

    public virtual void OnCollisionExit(GameObject gameObject, Collision2D other)
    {
    }
}
