using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerState : MonoBehaviour
{
    public bool isColliding;

    private void OnTriggerEnter2D(Collider2D other1)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other1)
    {
        isColliding = false;
    }
}
