using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityState
{
    Idle,
    Walk,
    Jump,
    Fall,
}

public class EntityStateHandlerComponent : MonoBehaviour
{
    private Dictionary<EntityState, EntityStateBase> _stateClassDict;
    
    [SerializeField] public EntityState state;
    private Rigidbody2D _rb;

    private float _inputValue;
    private float _actionValue;

    public bool cannotJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.EntityIdle += OnEntityIdle;
        EventHandler.EntityMove += OnEntityMove;
        EventHandler.EntityJump += OnEntityJump;
        EventHandler.EntityFall += OnEntityFall;
        
        _stateClassDict = new Dictionary<EntityState, EntityStateBase>()
        {
            {EntityState.Idle, new EntityStateBase()},
            {EntityState.Walk, new EntityStateWalk()},
            {EntityState.Jump, new EntityStateJump()},
            {EntityState.Fall, new EntityStateFall()}
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
    
    private void OnEntityJump(GameObject arg1, float arg2, float arg3)
    {
        if (gameObject != arg1 || cannotJump || state == EntityState.Fall) return;

        state = EntityState.Jump;
        _inputValue = arg2;
        _actionValue = arg3;
        cannotJump = true;
        _stateClassDict[state].Setup();
    }
    
    private void OnEntityFall(GameObject obj)
    {
        if (gameObject != obj) return;

        state = EntityState.Fall;
        _inputValue = 0f;
        _actionValue = 0f;
        cannotJump = true;
        _stateClassDict[state].Setup();
    }

    // Update is called once per frame
    void Update()
    {
        _stateClassDict[state].Execute(gameObject, _rb, _inputValue, _actionValue);
        
    }

    private void OnDestroy()
    {
        EventHandler.EntityIdle -= OnEntityIdle;
        EventHandler.EntityMove -= OnEntityMove;
        EventHandler.EntityJump -= OnEntityJump;
        EventHandler.EntityFall -= OnEntityFall;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _stateClassDict[state].OnCollision(gameObject, other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _stateClassDict[state].OnCollisionExit(gameObject, other);
    }
}
