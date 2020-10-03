using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingState : MonoBehaviour
{
    public bool isColliding;

    private void OnCollisionEnter2D(Collision2D other)
    {
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
    }
}
