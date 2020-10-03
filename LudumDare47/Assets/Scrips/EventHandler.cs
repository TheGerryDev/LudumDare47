using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler
{
    public static event Action<GameObject> EntityIdle;
    public static void OnEntityIdle(GameObject arg1)
    {
        EntityIdle?.Invoke(arg1);
    }
    
    public static event Action<GameObject, float, float> EntityMove;
    public static void OnEntityMove(GameObject arg1, float arg2, float arg3)
    {
        EntityMove?.Invoke(arg1, arg2, arg3);
    }
    
    public static event Action<GameObject, float, float> EntitySetupJump;
    public static void OnEntitySetupJump(GameObject arg1, float arg2, float arg3)
    {
        EntitySetupJump?.Invoke(arg1, arg2, arg3);
    }

    public static event Action<GameObject> EntityFall;
    public static void OnEntityFall(GameObject obj)
    {
        EntityFall?.Invoke(obj);
    }
    
    public static event Action<GameObject> EntityJumping;
    public static void OnEntityJumping(GameObject obj)
    {
        EntityJumping?.Invoke(obj);
    }

    public static event Action<GameObject> EntityChangeDirection;
    public static void OnEntityChangeDirection(GameObject obj)
    {
        EntityChangeDirection?.Invoke(obj);
    }
}
