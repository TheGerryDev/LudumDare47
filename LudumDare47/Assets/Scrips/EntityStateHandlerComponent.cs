using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventHandler;

public enum EntityState
{
    Idle,
    Walk,
    SetupJump,
    Jumping,
    Fall,
}

public class EntityStateHandlerComponent : MonoBehaviour
{
    private Dictionary<EntityState, EntityStateBase> _stateClassDict;
    
    [SerializeField] public EntityState state;
    private Rigidbody2D _rb;

    private float _inputValue;
    private float _actionValue;
    public bool isCollidingWithGround;

    public bool cannotJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        EntityIdle += OnEntityIdle;
        EntityMove += OnEntityMove;
        EntitySetupJump += OnEntitySetupJump;
        EntityFall += OnEntityFall;
        EntityJumping += OnEntityJumping;
        
        _stateClassDict = new Dictionary<EntityState, EntityStateBase>()
        {
            {EntityState.Idle, new EntityStateBase()},
            {EntityState.Walk, new EntityStateWalk()},
            {EntityState.SetupJump, new EntityStateSetupJump()},
            {EntityState.Fall, new EntityStateFall()},
            {EntityState.Jumping, new EntityStateJumping()}
        };
        
        state = EntityState.Idle;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEntityIdle(GameObject obj)
    {
        if (gameObject != obj) return;

        state = EntityState.Idle;
        _inputValue = 0f;
        _actionValue = 0f;
        cannotJump = false;
        _stateClassDict[state].Setup();
    }
    
    private void OnEntityMove(GameObject arg1, float arg2, float arg3)
    {
        if (gameObject != arg1) return;

        state = EntityState.Walk;
        _inputValue = arg2;
        _actionValue = arg3;
        _stateClassDict[state].Setup();
    }
    
    private void OnEntitySetupJump(GameObject arg1, float arg2, float arg3)
    {
        if (gameObject != arg1 || cannotJump) return;
        cannotJump = true;

        state = EntityState.SetupJump;
        _inputValue = arg2;
        _actionValue = arg3;
        _stateClassDict[state].Setup();
    }
    
    private void OnEntityFall(GameObject obj)
    {
        if (gameObject != obj || state == EntityState.Fall) return;
        cannotJump = true;

        state = EntityState.Fall;
        //_inputValue = 0f;
        //_actionValue = 0f;
        _stateClassDict[state].Setup();
    }
    
    private void OnEntityJumping(GameObject obj)
    {
        state = EntityState.Jumping;
        _stateClassDict[state].Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Automatic state changes
        if (_rb.velocity.y < 0f) EventHandler.OnEntityFall(gameObject);
        //if ((state == EntityState.Fall && _rb.velocity.y >= 0f)) EventHandler.OnEntityIdle(gameObject);
        
        _rb.velocity = _stateClassDict[state].Execute(gameObject, _rb, _inputValue, _actionValue);
        
        if (_rb.velocity == Vector2.zero && isCollidingWithGround) EventHandler.OnEntityIdle(gameObject);
        if (state == EntityState.SetupJump) state = EntityState.Jumping;
        //if (cannotJump && _isColliding && state != EntityState.Idle) _rb.velocity = new Vector2(0f, _rb.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Contains("GroundCollider") && child.gameObject.GetComponent<CollidingState>().isColliding)
            {
                isCollidingWithGround = true;
            }
        }
        _stateClassDict[state].OnCollision(gameObject, other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Contains("GroundCollider") && !child.gameObject.GetComponent<CollidingState>().isColliding)
            {
                isCollidingWithGround = false;
            }
        }
        _stateClassDict[state].OnCollisionExit(gameObject, other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _stateClassDict[state].OnTriggerStay(gameObject);
    }

    private void OnDestroy()
    {
        EntityIdle -= OnEntityIdle;
        EntityMove -= OnEntityMove;
        EntitySetupJump -= OnEntitySetupJump;
        EntityFall -= OnEntityFall;
        EntityJumping -= OnEntityJumping;
    }
}
