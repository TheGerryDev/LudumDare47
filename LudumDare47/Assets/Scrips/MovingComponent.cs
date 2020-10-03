using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingComponent : MonoBehaviour
{
    public int speed = 100;

    void OnMove(InputValue val)
    {
        EventHandler.OnEntityMove(gameObject, val.Get<float>(), speed);
    }
}
