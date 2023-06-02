using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bound: " + other.gameObject);
        if (other.CompareTag("Enemy") || other.CompareTag("Bullet") )
        {
            Destroy(other.gameObject);
        }
    }
}
