using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : MonoBehaviour
{
    public GameObject map;
    public Vector3 newPlayerPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        map.SetActive(true);
        GameObject.FindWithTag("Player").transform.position = newPlayerPos;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
