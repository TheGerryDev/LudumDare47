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
    
    public static event Action<GameObject, float, float> EntityJump;
    public static void OnEntityJump(GameObject arg1, float arg2, float arg3)
    {
        EntityJump?.Invoke(arg1, arg2, arg3);
    }

    public static event Action<GameObject> EntityFall;
    public static void OnEntityFall(GameObject obj)
    {
        EntityFall?.Invoke(obj);
    }
}
