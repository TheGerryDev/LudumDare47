using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGroundCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("GroundCollider"))
        {
            Destroy(gameObject);
        }
    }
}
