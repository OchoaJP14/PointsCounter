using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player entered the trigger!");
        }
        else
        {
            UnityEngine.Debug.Log("Something else entered: " + other.name);
        }
    }
}

